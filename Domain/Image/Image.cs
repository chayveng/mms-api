namespace mms_api.Domain.Image;

public class Image
{
    public Guid Id { get; set; }
    public string ImageId { get; set; } = "string";
    public string Name { get; set; } = "string";
    public string Type { get; set; } = "string";
    public byte[] File { get; set; }
    public DateTime CREATED_DATETIME { get; set; }
    public DateTime UPDATED_DATETIME { get; set; } 
}