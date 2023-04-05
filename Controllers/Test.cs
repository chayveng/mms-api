using Microsoft.AspNetCore.Mvc;

namespace mms_api.Controllers;

[ApiController]
[Route("[controller]")]
public class Test: Controller
{
    [HttpGet]
    public ActionResult Get()
    {
        return Ok("");
    }
}