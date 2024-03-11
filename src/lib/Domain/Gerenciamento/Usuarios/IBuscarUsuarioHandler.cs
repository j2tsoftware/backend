using Domain.Shared.Utils;

namespace Domain.Gerenciamento.Usuarios
{
    public interface IBuscarUsuarioHandler
    {
        Task<ValueResult<Usuario>> BuscarClientePorUserName(string username);
    }
}
