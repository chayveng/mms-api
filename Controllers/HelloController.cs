using Microsoft.AspNetCore.Mvc;

namespace mms_api.Controllers;

[ApiController]
[Route("")]
public class HelloController: Controller
{
    [HttpGet]
    public ActionResult Hello()
    {
        return Ok("Hello, MMS Api");
    }
}