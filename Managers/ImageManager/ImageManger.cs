using mms_api.Domain.Image;

namespace mms_api.Managers.ImageManager;

public class ImageManger
{
    private readonly IImageRepository _repository;

    public ImageManger(IImageRepository repository)
    {
        _repository = repository;
    }
    public IEnumerable<Image> GetAll()
    {
        return _repository.GetAll();
    }
    
    public async Task<Image> GetById(string imageId)
    {
        return await _repository.GetByImageId(imageId);
    }
    
    public async Task<string> GetImage(string imageId)
    {
        var image = await _repository.GetByImageId(imageId);
        var base64 = Convert.ToBase64String(image.File);
        var imageConfig = $"data:{image.Type};base64,{base64}";
        var imageConfig2 = $"data:image/{image.Type};base64,{base64}";
        var response = new
        {
            Config = imageConfig
        };
        return base64;
    }

    public Task<Image> Create(IFormFile data)
    {
        Stream stream = data.OpenReadStream();
        byte[] bytes = new BinaryReader(stream).ReadBytes((int)stream.Length);
        
        Image image = new Image
        {
            Id = new Guid(),
            ImageId = GenerateImagesId(),
            Name = data.FileName,
            Type = data.ContentType,
            File = bytes,
            CREATED_DATETIME = DateTime.UtcNow,
            UPDATED_DATETIME = DateTime.UtcNow
        };

        _repository.Create(image);
        _repository.SaveChanges();
        Task<Image> resImage = _repository.GetById(image.Id);
        return resImage;
    }
    
    public string Update(IFormFile newImage, Image oldImage)
    {
        Stream stream = newImage.OpenReadStream();
        byte[] bytes = new BinaryReader(stream).ReadBytes((int)stream.Length);

        oldImage.ImageId = oldImage.ImageId;
        oldImage.Name = newImage.FileName;
        oldImage.Type = newImage.ContentType;
        oldImage.File = bytes;
        oldImage.UPDATED_DATETIME =  DateTime.UtcNow;
        
        _repository.Update(oldImage);
        _repository.SaveChanges();
        return "Updated";
    }
    public string Delete(Image image)
    {
        _repository.Delete(image);
        _repository.SaveChanges();
        return "Deleted";
    }

    public string GenerateImagesId()
    {
        var date = DateTime.Now.ToString("yyyyMMdd");
        var searthDate = DateTime.Now.ToString("yyyyMM");
        var imagesId = "img" + searthDate;
        var id = _repository.Running(imagesId);
        var running = $"img{date}-{(id + 1).ToString().PadLeft(6, '0')}";
        return running;
    }
}