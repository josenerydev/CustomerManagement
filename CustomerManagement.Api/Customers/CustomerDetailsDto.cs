namespace CustomerManagement.Api.Customers
{
    public class CustomerDetailsDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }
        public string Industry { get; set; }
        public string EmailCampaign { get; set; }
        public string Status { get; set; }
    }
}
