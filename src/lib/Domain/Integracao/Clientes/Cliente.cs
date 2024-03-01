using Domain.Shared.Models;
using Domain.Shared.Utils;

namespace Domain.Integracao.Clientes
{
    public class Cliente : EntidadeBase
    {
        public string Documento { get; set; }
        public string Nome { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public DateTime DataInicioRelacionamento { get; set; }
        public DateTime? DataFimRelacionamento { get; set; }

        public Cliente()
        {
            Validar(this, new ClienteValidator());
        }

        public static ValueResult<Cliente> Criar(ClienteRequest requisicao)
        {
            if (requisicao == null)
                return ValueResult<Cliente>.Failure();

            var cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Documento = requisicao.Documento,
                Nome = requisicao.Nome,
                TipoPessoa = requisicao.TipoPessoa,
                DataInicioRelacionamento = requisicao.DataInicioRelacionamento,
                DataFimRelacionamento = requisicao.DataFimRelacionamento,
                DataCriacao = DateTime.Now
            };

            return cliente.DadosValidos
                ? ValueResult<Cliente>.Success(cliente)
                : ValueResult<Cliente>.Failure(cliente.Falhas);
        }
    }
}
