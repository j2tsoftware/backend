using Domain.Integracao.Shared;

namespace Domain.Integracao.AtualizacaoCliente
{
    public class AtualizacaoCliente : Cliente
    {
        public char TipoOperacao { get; set; }
        public char QualificadorOperacao { get; set; }
    }
}
