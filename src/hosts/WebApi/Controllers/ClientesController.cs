using Domain.Integracao.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IAdicionarClienteHandler _adicionarClienteHandler;

        public ClientesController(IAdicionarClienteHandler adicionarClienteHandler)
        {
            _adicionarClienteHandler = adicionarClienteHandler ?? throw new ArgumentNullException(nameof(adicionarClienteHandler));
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarCliente(ClienteRequest cliente)
        {
            var resultado = await _adicionarClienteHandler.AdicionarCliente(cliente);

            return resultado ? Ok(resultado) : BadRequest();    
        }
    }
}
