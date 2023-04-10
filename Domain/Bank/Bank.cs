namespace mms_api.Domain.Bank;

public class Bank
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Initials { get; set; } = string.Empty;
    public bool Status { get; set; } = false;
    public string ImageId { get; set; } = string.Empty;
    public DateTime CREATE_DATETIME { get; set; }
    public DateTime UPDATE_DATETIME { get; set; }
}