using Domain.Integracao.Clientes;
using Domain.Shared.Repositories;

namespace Infrastructure.Repositories
{
    public class ClientesRepositorio : RepositorioBase<Cliente>, IClientesRepositorio
    {
        public ClientesRepositorio(IUnitOfWork unitOfWork) : base(unitOfWork) {}

        public Task<Cliente> BuscarClientePorDocumento(int documento)
        {            
            return Obter(x => x.Documento.Equals(documento));  
        }

        public Task AdicionarCliente(Cliente cliente)
        {
            return Adicionar(cliente);
        }
    }
}
