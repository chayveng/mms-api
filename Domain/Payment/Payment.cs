namespace mms_api.Domain.Payment;

public class Payment
{
    public Guid Id { get; set; }
    public string Code { get; set; } = "string";
    public string Initials { get; set; } = "string";
    public string PaymentName { get; set; } = "string";

    public string ImageId { get; set; } = "string";
    public bool Status { get; set; } = false;
    public DateTime CREATED_DATETIME { get; set; }
    public DateTime UPDATED_DATETIME { get; set; }
}