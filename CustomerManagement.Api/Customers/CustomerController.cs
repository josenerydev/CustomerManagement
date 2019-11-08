using CSharpFunctionalExtensions;

using CustomerManagement.Api.Utils;
using CustomerManagement.Logic.Model;
using CustomerManagement.Logic.Utils;

using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Api.Customers
{
    public class CustomerController : BaseController
    {
        private readonly CustomerRepository customerRepository;
        private readonly IEmailGateway emailGateway;

        public CustomerController(UnitOfWork unitOfWork, IEmailGateway emailGateway)
            : base(unitOfWork)
        {
            customerRepository = new CustomerRepository(unitOfWork);
            this.emailGateway = emailGateway;
        }


        [HttpPost]
        [Route("customers")]
        public IActionResult Create(CreateCustomerDto dto)
        {
            Result<CustomerName> customerName = CustomerName.Create(dto.Name);
            Result<Email> primaryEmail = Email.Create(dto.PrimaryEmail);
            Result<Maybe<Email>> secondaryEmail = GetSecondaryEmail(dto.SecondaryEmail);
            Result<Industry> industry = Industry.Get(dto.Industry);

            Result result = Result.Combine(customerName, primaryEmail, secondaryEmail, industry);
            if (result.IsFailure)
                return Error(result.Error);

            var customer = new Customer(customerName.Value, primaryEmail.Value, secondaryEmail.Value, industry.Value);
            customerRepository.Save(customer);

            return Ok();
        }

        private Result<Maybe<Email>> GetSecondaryEmail(string secondaryEmail)
        {
            if (secondaryEmail == null)
                return Result.Ok<Maybe<Email>>(null);

            return Email.Create(secondaryEmail)
                .Map(email => (Maybe<Email>)email);
        }

        [HttpGet]
        [Route("customers/{id}")]
        public IActionResult Get(long id)
        {
            Maybe<Customer> customerOrNothing = customerRepository.GetById(id);
            if (customerOrNothing.HasNoValue)
                return Error("Customer with such Id is not found: " + id);

            Customer customer = customerOrNothing.Value;


            var dto = new CustomerDetailsDto
            {
                Id = customer.Id,
                Name = customer.Name.Value,
                PrimaryEmail = customer.PrimaryEmail.Value,
                Industry = customer.EmailingSettings.Industry.Name,
                EmailCampaign = customer.EmailingSettings.EmailCampaign.ToString(),
                Status = customer.Status.ToString()
            };

            if (customer.SecondaryEmail.HasNoValue)
                dto.SecondaryEmail = null;

            return Ok(dto);
        }

        [HttpDelete]
        [Route("customers/{id}/emailing")]
        public IActionResult DisableEmailing(long id)
        {
            Maybe<Customer> customerOrNothing = customerRepository.GetById(id);
            if (customerOrNothing.HasNoValue)
                return Error("Customer with such Id is not found: " + id);

            Customer customer = customerOrNothing.Value;
            customer.DisableEmailing();

            return Ok();
        }

        [HttpPut]
        [Route("customers/{id}")]
        public IActionResult Update(UpdateCustomerDto dto)
        {
            Result<Customer> customerResult = customerRepository.GetById(dto.Id)
                .ToResult("Customer with such Id is not found: " + dto.Id);
            Result<Industry> industryResult = Industry.Get(dto.Industry);

            return Result.Combine(customerResult, industryResult)
                .Tap(() => customerResult.Value.UpdateIndustry(industryResult.Value))
                .Finally(result => result.IsSuccess ? Ok() : Error(result.Error));
        }

        [HttpPost]
        [Route("customers/{id}/promotion")]
        public IActionResult Promote(long id)
        {
            return customerRepository.GetById(id)
                .ToResult("Customer with such Id is not found: " + id)
                .Ensure(customer => customer.CanBePromoted(), "The customer has the highest status possible")
                .Tap(customer => customer.Promote())
                .Tap(customer => emailGateway.SendPromotionNotification(customer.PrimaryEmail, customer.Status))
                .Finally(result => result.IsSuccess ? Ok() : Error(result.Error));
        }
    }
}
