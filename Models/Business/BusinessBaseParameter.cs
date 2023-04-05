namespace mms_api.Models.Business;

public class BusinessBaseParameter
{
    public Guid Id { get; set; } 
    public string BusinessId { get; set; }
    public string TypeName { get; set; }
    public bool Status { get; set; } 
}