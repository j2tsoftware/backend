using Domain.Integracao.AtualizacoesRelacionamentos;
using Domain.Shared.Utils;

namespace Application.Handlers.Integracao.AtualizacoesRelacionamentos
{
    public class AtualizacaoRelacionamentoHandler : IAtualizacaoRelacionamentoHandler
    {
        private readonly IAtualizacoesRelacionamentosRepository _repository;

        public AtualizacaoRelacionamentoHandler(IAtualizacoesRelacionamentosRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ValueResult<AtualizacaoRelacionamento>> AtualizarRelacionamentoClientes(AtualizacaoRelacionamentoRequest requisicao)
        {
            _repository.UnitOfWork.BegintTransaction();
            
            try
            {
                var atualizacao = AtualizacaoRelacionamentoFactory.CriarPorRequisicao(requisicao, 1);
                
                if (atualizacao.Succeeded)
                    return atualizacao;

                await _repository.AdicionarAtualizacaoDeRelacionamentos(atualizacao.Value);
                await _repository.UnitOfWork.CommitChanges();
                await _repository.UnitOfWork.CommitTransaction();

                return atualizacao;
            }
            catch (Exception ex)
            {
                _repository.UnitOfWork.Rollback();
                return ValueResult<AtualizacaoRelacionamento>.Failure($"Falha ao adicionar atualizações: {ex.Message}");
            }
        }
    }
}
