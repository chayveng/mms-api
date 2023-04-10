using Microsoft.AspNetCore.Mvc;
using mms_api.Domain.Payment;
using mms_api.Managers.PaymentManeger;

namespace mms_api.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : Controller
{
    private readonly ILogger<PaymentController> _logger;
    private readonly PaymentManager _manager;
    private readonly IPaymentRepository _repository;

    public PaymentController(ILogger<PaymentController> logger, PaymentManager manager, IPaymentRepository repository)
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


    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(Guid id)
    {
        try
        {
            var data = await _manager.GetById(id);
            if (data != null) { return Ok(data); }
            return NotFound();
        }
        catch (Exception e)
        {
            _logger.LogError("Get By id is error: {EMessage}", e.Message);
            return BadRequest();
        }
    }

    [HttpGet("search/{name}")]
    public async Task<ActionResult> Search(string name)
    {
        //var result = await _repository.GetByName(name);
        var result = await _repository.Search(name);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }

    [HttpPost("create")]
    public ActionResult Create([FromBody] Payment payment)
    {
        try
        {
            var response = _manager.Create(payment);
            return Ok("Created");
        }
        catch (Exception e)
        {
            _logger.LogError("Create is error: {EMessage}", e.Message);
            return BadRequest();
        }
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult> Update([FromBody] Payment payment, Guid id)
    {
        try
        {
            var result = await _manager.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var response = _manager.Update(payment, result);
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

    [HttpGet("running")]
    public ActionResult Running()
    {
        return Ok();
    }
}