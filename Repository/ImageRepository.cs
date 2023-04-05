using Microsoft.EntityFrameworkCore;
using mms_api.Domain.Image;
using mms_api.Infrastucture;

namespace mms_api.Repository;

public class ImageRepository : IImageRepository
{
    private readonly DatabaseContext _context;

    public ImageRepository(DatabaseContext context)
    {
        _context = context;
    }


    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

    public IQueryable<Image> GetQuery()
    {
        return _context.Images;
    }

    public int Running(string imageId)
    {
        
        var count = _context.Images.Where(e => e.ImageId.Contains(imageId));
        return count.Count();
    }

    public IEnumerable<Image> GetAll()
    {
        return _context.Images.ToList();
    }

    public async Task<Image> GetById(Guid id)
    {
        var image = await _context.Images.FirstOrDefaultAsync(e => e.Id == id);
        return image;
    }
    
    public async Task<Image> GetByImageId(string imageId)
    {
        var image = await _context.Images.FirstOrDefaultAsync(e => e.ImageId == imageId);
        return image;
    }
    

    public Image Create(Image image)
    {
        var entity = _context.Images.Add(image);
        return entity.Entity;
    }

    public Image Update(Image image)
    {
        var entity = _context.Images.Update(image);
        return entity.Entity;
    }

    public Image Delete(Image image)
    {
        var entity = _context.Images.Remove(image);
        return entity.Entity;
    }
}