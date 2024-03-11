using Domain.Gerenciamento;
using Domain.Gerenciamento.Usuarios;
using Domain.Shared.Repositories;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : RepositorioBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IUnitOfWork unitOfWork, DatabaseContext context) : base(unitOfWork, context) { }

        public Task<Usuario> BuscarClientePorUserName(string username)
        {
            return Obter(x => x.Nome.Equals(username));
        }
    }
}
