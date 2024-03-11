using Domain.Gerenciamento.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IBuscarUsuarioHandler _buscarUsuarioHandler;

        public UsuarioController(
            IBuscarUsuarioHandler buscarUsuarioHandler)
        {
            _buscarUsuarioHandler = buscarUsuarioHandler ?? throw new ArgumentNullException(nameof(buscarUsuarioHandler));
        }


        [HttpGet("{username}")]
        public async Task<ActionResult> BuscarUsuario(string username)
        {
            var resultado = await _buscarUsuarioHandler.BuscarClientePorUserName(username);

            return resultado ? Ok(resultado.Value) : BadRequest(resultado.FailureDetails);
        }
    }
}
