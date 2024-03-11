using Domain.Gerenciamento;
using Domain.Gerenciamento.Usuarios;
using Domain.Shared.Utils;

namespace Application.Handlers.Usuarios
{
    public class BuscarUsuarioHandler : IBuscarUsuarioHandler
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public BuscarUsuarioHandler(IUsuarioRepository usuarioRepositorio)
        {
            _usuarioRepository = usuarioRepositorio ?? throw new ArgumentNullException(nameof(usuarioRepositorio));
        }

        public async Task<ValueResult<Usuario>> BuscarClientePorUserName(string username)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscarClientePorUserName(username);

                return usuario != null
                    ? ValueResult<Usuario>.Success(usuario)
                    : ValueResult<Usuario>.Failure("Usuário não encontrado");
            }
            catch (Exception ex)
            {
                return ValueResult<Usuario>.Failure($"Erro ao buscar Usuário: {ex.Message}");
            }
        }
    }
}
