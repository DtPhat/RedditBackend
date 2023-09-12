using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blueddit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Hello");
        }
    }
}
