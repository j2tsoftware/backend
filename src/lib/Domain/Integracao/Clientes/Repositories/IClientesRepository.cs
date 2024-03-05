using Domain.Shared.Repositories;

namespace Domain.Integracao.Clientes
{
    public interface IClientesRepository : IBaseRepository<Cliente>
    {
        Task AdicionarCliente(Cliente cliente);
        Task<Cliente> BuscarClientePorDocumento(string documento);
    }
}
