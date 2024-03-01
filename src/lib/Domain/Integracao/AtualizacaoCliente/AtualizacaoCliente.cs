using Domain.Integracao.Clientes;

namespace Domain.Integracao.AtualizacaoCliente
{
    public class AtualizacaoCliente : Cliente
    {
        public char TipoOperacao { get; set; }
        public char QualificadorOperacao { get; set; }
    }
}
