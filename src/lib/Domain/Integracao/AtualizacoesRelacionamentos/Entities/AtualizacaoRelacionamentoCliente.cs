using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Integracao.AtualizacoesRelacionamentos
{
    public class AtualizacaoRelacionamentoCliente
    {
        public Guid Id { get; set; }
        public string Documento { get; set; }
        public char TipoOperacao { get; set; }
        public char QualificadorOperacao { get; set; }
        public Guid AtualizacaoRelacionamentoId { get; set; }
        public DateTime DataInicioRelacionamento { get; set; }
        public DateTime? DataFimRelacionamento { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual AtualizacaoRelacionamento AtualizacaoRelacionamento { get; set; }
    }
}
