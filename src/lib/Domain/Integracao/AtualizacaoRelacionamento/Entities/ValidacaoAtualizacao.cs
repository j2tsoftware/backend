using Domain.Integracao.Shared;

namespace Domain.Integracao.AtualizacaoRelacionamento
{
    public class ValidacaoAtualizacao
    {
        public BlocoControle BlocoDeControle { get; set; }
        public IEnumerable<ValidacaoAtualizacaoRelacionamento> ValidacoesClientes { get; set; }
        public int QuantidadeDeErros { get; set; }
        public int QuantidadeDeOperacoesAceitas { get; set; }
        public DateTime DataHoraBacen { get; set; }
        public DateTime DataMovimentacao { get; set; }
    }
}
