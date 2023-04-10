namespace mms_api.Domain.Business
{
    public class Business
    {
        public Guid Id { get; set; }
        public string BusinessId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
        public DateTime CREATE_DATETIME { get; set; }
        public DateTime UPDATE_DATETIME { get; set; }

    }
}