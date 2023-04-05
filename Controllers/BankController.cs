using Microsoft.AspNetCore.Mvc;
using mms_api.Domain.Bank;
using mms_api.Managers.BankManager;

namespace mms_api.Controllers;

[ApiController]
[Route("[controller]")]
public class BankController : Controller
{
    private readonly ILogger<BankController> _logger;
    private readonly BankManager _manager;

    public BankController(ILogger<BankController> logger, BankManager manager)
    {
        _logger = logger;
        _manager = manager;
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
    public ActionResult Create([FromBody] Bank bank)
    {
        try
        {
            var response = _manager.Create(bank);
            return Ok("Created");
        }
        catch (Exception e)
        {
            _logger.LogError("Create is error: {EMessage}", e.Message);
            return BadRequest();
        }
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult> Update([FromBody] Bank bank, Guid id)
    {
        try
        {
            var result = await _manager.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var response = _manager.Update(bank, result);
            return Ok("Updated");
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
            return Ok("Delete");
        }
        catch (Exception e)
        {
            _logger.LogError("Delete is error: {EMessage}", e.Message);
            return BadRequest();
        }
    }
}