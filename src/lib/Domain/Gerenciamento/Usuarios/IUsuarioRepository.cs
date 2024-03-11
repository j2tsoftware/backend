using Domain.Shared.Repositories;

namespace Domain.Gerenciamento.Usuarios
{
    public interface IUsuarioRepository : IRepositorioBase<Usuario>
    {
        Task<Usuario> BuscarClientePorUserName(string username);
    }
}
