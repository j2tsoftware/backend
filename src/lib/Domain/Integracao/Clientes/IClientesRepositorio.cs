using Domain.Shared.Repositories;

namespace Domain.Integracao.Clientes
{
    public interface IClientesRepositorio : IRepositorioBase<Cliente>
    {
        Task AdicionarCliente(Cliente cliente);
        Task<Cliente> BuscarClientePorDocumento(int documento);
    }
}
