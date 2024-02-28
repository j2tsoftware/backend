using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
        }

        [HttpGet(Name = "Home")]
        public ActionResult Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("Test")]
        public ActionResult Test()
        {
            return Ok("Test");
        }
    }
}