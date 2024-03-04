using Domain.Shared.Repositories;

namespace Domain.Integracao.Clientes
{
    public interface IClientesRepository : IRepositorioBase<Cliente>
    {
        Task AdicionarCliente(Cliente cliente);
        Task<Cliente> BuscarClientePorDocumento(string documento);
    }
}
