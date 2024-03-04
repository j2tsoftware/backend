using Domain.Integracao.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IAdicionarClienteHandler _adicionarClienteHandler;
        private readonly IBuscarClienteHandler _buscarClienteHandler;

        public ClientesController(
            IAdicionarClienteHandler adicionarClienteHandler,
            IBuscarClienteHandler buscarClienteHandler)
        {
            _adicionarClienteHandler = adicionarClienteHandler ?? throw new ArgumentNullException(nameof(adicionarClienteHandler));
            _buscarClienteHandler = buscarClienteHandler ?? throw new ArgumentNullException(nameof(buscarClienteHandler));
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarCliente(ClienteRequest cliente)
        {
            var resultado = await _adicionarClienteHandler.AdicionarCliente(cliente);

            return resultado ? Ok(resultado.Value) : BadRequest(resultado.FailureDetails);   
        }

        [HttpGet("{documento}")]
        public async Task<ActionResult> BuscarCliente(string documento)
        {
            var resultado = await _buscarClienteHandler.BuscarClientePorDocumento(documento);

            return resultado ? Ok(resultado.Value) : BadRequest(resultado.FailureDetails);
        }
    }
}
