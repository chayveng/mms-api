namespace mms_api.Domain.Business
{
    public class Business
    {
        public Guid Id { get; set; } = new Guid();
        public string BusinessId { get; set; } = "string";
        public string TypeName { get; set; }  = "string";
        public bool Status { get; set; } = false;
        public DateTime CREATE_DATETIME { get; set; } 
        public DateTime UPDATE_DATETIME { get; set; }

    }
}