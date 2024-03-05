using Domain.Shared.Utils;

namespace Domain.Integracao.AtualizacoesRelacionamentos
{
    public interface IAtualizacaoRelacionamentoHandler
    {
        Task<ValueResult<AtualizacaoRelacionamento>> AtualizarRelacionamentoClientes(AtualizacaoRelacionamentoRequest requisicao);
    }
}
