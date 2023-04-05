namespace mms_api.Domain.Bank;

public class Bank
{
    public Guid Id { get; set; }
    public string BankName { get; set; } = "string";
    public string Initials { get; set; } = "string";
    public bool Status { get; set; } = false;
    public string ImageId { get; set; } = "string";
    public DateTime CREATE_DATETIME { get; set; }
    public DateTime UPDATE_DATETIME { get; set; }
}