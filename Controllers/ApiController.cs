using Microsoft.AspNetCore.Mvc;

namespace VueJsAspNetCore.Controllers
{
    //[Produces("application/json")]
    [Route("api")]
    public class ApiController : Controller
    {
      [HttpGet]
      [Route("hello")]
      public IActionResult Hello()
      {
        var msg = new { Message = "Hello World" };
        return this.Ok(msg);
      }

  }
}