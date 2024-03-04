using Domain.Shared.Utils;

namespace Domain.Integracao.Clientes
{
    public interface IAdicionarClienteHandler
    {
        Task<ValueResult<Cliente>> AdicionarCliente(ClienteRequest requisicao);
    }
}
