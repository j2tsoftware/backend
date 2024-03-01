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
            return Ok(new { Message = "Backend CCS - Versão 0.0.1 "});
        }
    }
}