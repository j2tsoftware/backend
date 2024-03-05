using Domain.Shared.Repositories;

namespace Domain.Integracao.AtualizacoesRelacionamentos
{
    public interface IAtualizacoesRelacionamentosRepository : IBaseRepository<AtualizacaoRelacionamento>
    {
        Task AdicionarAtualizacaoDeRelacionamentos(AtualizacaoRelacionamento atualizacao);
    }
}
