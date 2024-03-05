using Domain.Integracao.Clientes;
using Domain.Shared.Repositories;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class ClientesRepository : BaseRepository<Cliente>, IClientesRepository
    {
        public ClientesRepository(
            IUnitOfWork unitOfWork, 
            DatabaseContext context) 
            : base(unitOfWork, context) { }

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
