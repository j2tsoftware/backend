using Domain.Shared.Models;
using Domain.Shared.Utils;

namespace Domain.Integracao.Clientes
{
    public class Cliente : EntidadeBase
    {
        public Guid Id { get; set; }
        public string Documento { get; set; }
        public string Nome { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public DateTime DataInicioRelacionamento { get; set; }
        public DateTime? DataFimRelacionamento { get; set; }

        public Cliente() { }

        public Cliente(
            string nome,
            string documento,
            TipoPessoa tipoPessoa,
            DateTime dataInicioRelacionamento,
            DateTime? dataFimRelacionamento)
        {
            Id = Guid.NewGuid();
            Documento = documento;
            Nome = nome;
            TipoPessoa = tipoPessoa;
            DataInicioRelacionamento = dataInicioRelacionamento;
            DataFimRelacionamento = dataFimRelacionamento;
            DataCriacao = DateTime.Now;

            Validar(this, new ClienteValidator());
        }

        public static ValueResult<Cliente> Criar(ClienteRequest requisicao)
        {
            if (requisicao == null)
                return ValueResult<Cliente>.Failure();

            var cliente = new Cliente(
                requisicao.Nome,
                requisicao.Documento,
                requisicao.TipoPessoa,
                requisicao.DataInicioRelacionamento,
                requisicao.DataFimRelacionamento);

            return cliente.DadosValidos
                ? ValueResult<Cliente>.Success(cliente)
                : ValueResult<Cliente>.Failure(cliente.Falhas);
        }
    }
}
