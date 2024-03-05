using Domain.Integracao.Shared;
using Domain.Shared.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Integracao.AtualizacoesRelacionamentos
{
    public class AtualizacaoRelacionamento : EntidadeBase
    {
        public Guid Id { get; set; }
        public IEnumerable<AtualizacaoRelacionamentoCliente> Clientes { get; set; }
        public int QuantidadeOperacao { get; set; }
        public int NumeroRemessa { get; set; }
        public DateTime DataMovimentacao { get; set; }

        [NotMapped]
        public BlocoControle BlocoDeControle { get; set; }

        public AtualizacaoRelacionamento() { }

        public AtualizacaoRelacionamento(IEnumerable<AtualizacaoRelacionamentoCliente> listaDeClientes, int numeroRemessa)
        {
            Clientes = listaDeClientes;
            QuantidadeOperacao = Clientes != null && Clientes.Any() ? Clientes.Count() : 0;
            DataMovimentacao = DateTime.Now;
            NumeroRemessa = numeroRemessa;
            BlocoDeControle = new BlocoControle(TagsArquivos.AtualizacaoCliente, numeroRemessa);

            Validar(this, new AtualizacaoRelacionamentoValidator());
        }
    }
}
