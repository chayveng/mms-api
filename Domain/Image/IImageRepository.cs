namespace mms_api.Domain.Image;

public interface IImageRepository
{
    bool SaveChanges();
    IQueryable<Image> GetQuery();

    int Running(string imageId);
    IEnumerable<Image> GetAll();
    Task<Image> GetById(Guid id);
    Task<Image> GetByImageId(string imageId);
    Image Create(Image image);
    Image Update(Image image);
    Image Delete(Image image);
}