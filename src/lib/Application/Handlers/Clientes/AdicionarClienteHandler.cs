using Domain.Integracao.Clientes;
using Domain.Shared.Utils;

namespace Application.Handlers.Clientes
{
    public class AdicionarClienteHandler : IAdicionarClienteHandler
    {
        private readonly IClientesRepository _clientesRepository;

        public AdicionarClienteHandler(IClientesRepository clientesRepositorio)
        {
            _clientesRepository = clientesRepositorio ?? throw new ArgumentNullException(nameof(clientesRepositorio));
        }

        public async Task<ValueResult<Cliente>> AdicionarCliente(ClienteRequest requisicao)
        {
            try
            {
                var cliente = Cliente.Criar(requisicao);

                if (!cliente.Succeeded)
                    return cliente;

                await _clientesRepository.AdicionarCliente(cliente.Value);
                await _clientesRepository.UnitOfWork.CommitChanges();

                return cliente;
            }
            catch (Exception ex)
            {
                return ValueResult<Cliente>.Failure($"Erro ao salvar Cliente: {ex.Message}");
            }
        }
    }
}