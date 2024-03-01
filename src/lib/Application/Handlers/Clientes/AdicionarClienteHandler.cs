using Domain.Integracao.Clientes;
using Domain.Shared.Utils;

namespace Application.Handlers.Clientes
{
    public class AdicionarClienteHandler : IAdicionarClienteHandler
    {
        private readonly IClientesRepositorio _clientesRepositorio;

        public AdicionarClienteHandler(IClientesRepositorio clientesRepositorio)
        {
            _clientesRepositorio = clientesRepositorio ?? throw new ArgumentNullException(nameof(clientesRepositorio));
        }

        public async Task<ValueResult<Cliente>> AdicionarCliente(ClienteRequest requisicao)
        {
            try
            {
                var cliente = Cliente.Criar(requisicao);

                if (!cliente.Succeeded)
                    return cliente;

                await _clientesRepositorio.AdicionarCliente(cliente.Value);
                await _clientesRepositorio.UnitOfWork.CommitChanges();

                return cliente;
            }
            catch (Exception ex)
            {
                return ValueResult<Cliente>.Failure($"Erro ao salvar Cliente: {ex.Message}");
            }
        }
    }
}