using System.Text.Json.Serialization;

namespace Domain.Integracao.AtualizacoesRelacionamentos
{
    public class AtualizacaoRelacionamentoClienteRequest
    {
        [JsonPropertyName("documento")]
        public string Documento { get; set; }

        [JsonPropertyName("tipoOperacao")]
        public char TipoOperacao { get; set; }

        [JsonPropertyName("qualificadorOperacao")]
        public char QualificadorOperacao { get; set; }

        [JsonPropertyName("dataInicioRelacionamento")]
        public DateTime DataInicioRelacionamento { get; set; }

        [JsonPropertyName("dataFimRelacionamento")]
        public DateTime? DataFimRelacionamento { get; set; }
    }
}
