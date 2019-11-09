
using CustomerManagement.Logic.SeedWork;

using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Api.Utils
{
    public class BaseController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public BaseController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected new IActionResult Ok()
        {
            unitOfWork.Commit();
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            unitOfWork.Commit();
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(Envelope.Error(errorMessage));
        }
    }
}
