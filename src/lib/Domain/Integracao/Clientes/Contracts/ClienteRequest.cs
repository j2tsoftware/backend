using System.Text.Json.Serialization;

namespace Domain.Integracao.Clientes
{
    public class ClienteRequest
    {
        [JsonPropertyName("documento")]
        public string Documento { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("tipoPessoa")]
        public TipoPessoa TipoPessoa { get; set; }

        [JsonPropertyName("dataInicioRelacionamento")]
        public DateTime DataInicioRelacionamento { get; set; }

        [JsonPropertyName("dataFimRelacionamento")]
        public DateTime? DataFimRelacionamento { get; set; }
    }
}
