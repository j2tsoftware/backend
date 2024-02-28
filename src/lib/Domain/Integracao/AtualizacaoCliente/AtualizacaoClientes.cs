using Domain.Integracao.Shared;

namespace Domain.Integracao.AtualizacaoCliente
{
    public class AtualizacaoClientes
    {
        public BlocoControle BlocoDeControle { get; set; }
        public IEnumerable<AtualizacaoCliente> Clientes { get; set; }
        public int QuantidadeOperacao { get; set; }
        public DateTime DataMovimentacao { get; set; }

        public AtualizacaoClientes(IEnumerable<AtualizacaoCliente> listaDePessoas, int numeroRemessa)
        {
            Clientes = listaDePessoas;
            QuantidadeOperacao = Clientes != null && Clientes.Any() ? Clientes.Count() : 0;
            DataMovimentacao = DateTime.Now;
            BlocoDeControle = new BlocoControle
            {
                NomeArquivo = TagsArquivos.AtualizacaoCliente,
                IdentificadorEmissor = 1,
                IdentificadorDestinatario = 1,
                NumeroRemessaArquivo = numeroRemessa
            };
        }
    }
}
