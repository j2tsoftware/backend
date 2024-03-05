using System.Text.Json.Serialization;

namespace Domain.Integracao.AtualizacoesRelacionamentos
{
    public class AtualizacaoRelacionamentoRequest
    {
        [JsonPropertyName("clientes")]
        public List<AtualizacaoRelacionamentoClienteRequest> Clientes { get; set; }
    }
}
