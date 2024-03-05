using Domain.Integracao.Shared;

namespace Domain.Integracao.AtualizacoesRelacionamentos
{
    public class RespostaAtualizacao
    {
        public BlocoControle BlocoDeControle { get; set; }
        public char SituacaoArquivo { get; set; }
        public string Erro { get; set; }
        public int UltimoNumeroRemessaArquivo { get; set; }
        public DateTime DataHoraBacen { get; set; }
        public DateTime DataMovimentacao { get; set; }
    }
}
