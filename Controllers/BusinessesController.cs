using Microsoft.AspNetCore.Mvc;
using mms_api.Domain.Business;
using mms_api.Managers.BusinessManager;

namespace mms_api.Controllers;

[ApiController]
[Route("[controller]")]
public class BusinessesController : Controller
{
    private readonly ILogger<BusinessesController> _logger;
    private readonly BusinessManager _manager;
    private readonly IBusinessRepository _repository;

    public BusinessesController(ILogger<BusinessesController> logger, BusinessManager manager, IBusinessRepository repository)
    {
        _logger = logger;
        _manager = manager;
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


    [HttpPost("create")]
    public ActionResult Create([FromBody] Business business)
    {
        try
        {
            var response = _manager.Create(business);
            return Ok("Created");
        }
        catch (Exception e)
        {
            _logger.LogError("Create is error: {EMessage}", e.Message);
            return BadRequest();
        }
    }
    
    [HttpPost("test")]
    public ActionResult Test([FromBody] Business business)
    {
        return Ok(business);
    }


    [HttpPut("update/{id}")]
    public async Task<ActionResult> Update([FromBody] Business business, Guid id)
    {
        try
        {
            var result = await _manager.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var response =  _manager.Update(business, result);
            return Ok("Updated");
            // return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError("Update is error: {EMessage}", e.Message);
            return BadRequest();
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        try
        {
            var result = await _manager.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            
            var response = _manager.Delete(result);
            // return Ok(result);
            return Ok("Delete");
        }
        catch (Exception e)
        {
            _logger.LogError("Delete is error: {EMessage}", e.Message);
            return BadRequest();
        }
    }
    
    [HttpGet("running/{businessId}")]
    public ActionResult Running(string businessId)
    {
        return Ok(_repository.Running(businessId));
    }
}