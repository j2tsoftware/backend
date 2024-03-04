using Domain.Shared.Utils;

namespace Domain.Integracao.Clientes
{
    public interface IBuscarClienteHandler
    {
        Task<ValueResult<Cliente>> BuscarClientePorDocumento(string documento);
    }
}
