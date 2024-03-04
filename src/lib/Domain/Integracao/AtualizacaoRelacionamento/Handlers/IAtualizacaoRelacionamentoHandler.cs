using Domain.Shared.Utils;

namespace Domain.Integracao.AtualizacaoRelacionamento
{
    public interface IAtualizacaoRelacionamentoHandler
    {
        Task<ValueResult<bool>> AtualizarRelacionamentoClientes(List<string> documentos);
    }
}
