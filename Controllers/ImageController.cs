using System.Text;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using mms_api.Domain.Image;
using mms_api.Managers.ImageManager;
using Newtonsoft.Json;

namespace mms_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : Controller
{
    private readonly ILogger<ImageController> _logger;
    private readonly ImageManger _manager;
    private readonly IImageRepository _repository;

    public ImageController(ILogger<ImageController> logger, ImageManger manger, IImageRepository repository)
    {
        _logger = logger;
        _manager = manger;
        _repository = repository;
    }

    [HttpGet("all")]
    public ActionResult GetAll()
    {
        try
        {
            var data = _manager.GetAll();
            return Ok(data);
        }
        catch (Exception e)
        {
            _logger.LogError("Get all is error: {EMessage}", e.Message);
            return BadRequest();
        }
    }
    
    [HttpGet("{imageId}")]
    public async Task<IActionResult> GetImage(string imageId)
    {
        try
        {
            var res = await _manager.GetImage(imageId);
            var image = await _repository.GetByImageId(imageId);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(image);

            // Byte[] c = image.File;
            // string path = @"StaticFile/Images/iu.png";
            // Byte[] b = System.IO.File.ReadAllBytes(path);
            // Byte[] b = image.File;
            // return File(b, image.Type);
            // return File(c, "image/png");  
            // var response = await _manager.GetImage(imageId);
            // return Content(response,"text/plain");  
        }
        catch (Exception e)
        {
            _logger.LogError("Get image is error: {EMessage}", e.Message);
            return BadRequest();
        }
    }


    // [HttpGet("{imageId}")]
    [HttpGet("Download/{imageId}")]
    public async Task<IActionResult> Download(string imageId)
    {
        try
        {
            var res = await _manager.GetImage(imageId);
            var image = await _repository.GetByImageId(imageId);
            if (res == null)
            {
                return NotFound();
            }

            // Byte[] c = image.File;
            // string path = @"StaticFile/Images/iu.png";
            // Byte[] b = System.IO.File.ReadAllBytes(path);
            Byte[] b = image.File;
            return File(b, image.Type);
            // return File(c, "image/png");  
            // var response = await _manager.GetImage(imageId);
            // return Content(response,"text/plain");  
        }
        catch (Exception e)
        {
            _logger.LogError("Get image is error: {EMessage}", e.Message);
            return BadRequest();
        }
    }

    [HttpPost("upload")]
    public async Task<ActionResult<Image>> Upload([FromForm] IFormFile data)
    {
        try
        {
            var res = await _manager.Create(data);
            return Ok(res);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("update/{imageId}")]
    public async Task<ActionResult> Update([FromForm] IFormFile data, string imageId)
    {
        try
        {
            var result = await _manager.GetById(imageId);
            if (result == null)
            {
                return NotFound();
            }

            var res = _manager.Update(data, result);
            return Ok(res);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete("delete/{imageId}")]
    public async Task<ActionResult> Delete(string imageId)
    {
        try
        {
            var result = await _manager.GetById(imageId);
            if (result == null)
            {
                return NotFound();
            }

            var res = _manager.Delete(result);
            return Ok("Data is: " + res);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}