using Domain.Integracao.AtualizacoesRelacionamentos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtualizacaoRelacionamentoController : ControllerBase
    {
        private readonly IAtualizacaoRelacionamentoHandler _handler;

        public AtualizacaoRelacionamentoController(IAtualizacaoRelacionamentoHandler handler)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        [HttpPost]
        public async Task<ActionResult> AtualizarRelacionamentoClientes(AtualizacaoRelacionamentoRequest requisicao)
        {
            var resultado = await _handler.AtualizarRelacionamentoClientes(requisicao);

            return resultado ? Ok(resultado.Value) : BadRequest(resultado.FailureDetails);
        }
    }
}
