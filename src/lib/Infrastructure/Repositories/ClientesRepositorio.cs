using Domain.Integracao.Clientes;
using Domain.Shared.Repositories;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class ClientesRepositorio : RepositorioBase<Cliente>, IClientesRepositorio
    {
        public ClientesRepositorio(IUnitOfWork unitOfWork, DatabaseContext context) : base(unitOfWork, context) {}

        public Task<Cliente> BuscarClientePorDocumento(string documento)
        {            
            return Obter(x => x.Documento.Equals(documento));  
        }

        public Task AdicionarCliente(Cliente cliente)
        {
            return Adicionar(cliente);
        }
    }
}
