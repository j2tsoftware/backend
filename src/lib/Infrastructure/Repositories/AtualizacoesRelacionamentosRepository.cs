using Domain.Integracao.AtualizacoesRelacionamentos;
using Domain.Shared.Repositories;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class AtualizacoesRelacionamentosRepository 
        : BaseRepository<AtualizacaoRelacionamento>, IAtualizacoesRelacionamentosRepository
    {
        public AtualizacoesRelacionamentosRepository(
            IUnitOfWork unitOfWork, 
            DatabaseContext context) 
            : base(unitOfWork, context) { }

        public Task AdicionarAtualizacaoDeRelacionamentos(AtualizacaoRelacionamento atualizacao)
        {
            return Adicionar(atualizacao);
        }
    }
}
