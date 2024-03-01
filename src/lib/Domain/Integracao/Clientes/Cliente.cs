using Domain.Integracao.Shared;

namespace Domain.Integracao.Clientes
{
    public class Cliente : EntidadeBase
    {
        public string Documento { get; set; }
        public string Nome { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public DateTime DataInicioRelacionamento { get; set; }
        public DateTime? DataFimRelacionamento { get; set; }

        public static Cliente MapearPorRequisicao(ClienteRequest requisicao)
        {
            return new Cliente
            {
                Id = Guid.NewGuid(),
                Documento = requisicao.Documento,
                Nome = requisicao.Nome,
                TipoPessoa = requisicao.TipoPessoa,
                DataInicioRelacionamento = requisicao.DataInicioRelacionamento,
                DataFimRelacionamento = requisicao.DataFimRelacionamento,
                DataCriacao = DateTime.Now
            };
        }
    }
}
