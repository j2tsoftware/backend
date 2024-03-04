using Domain.Integracao.Clientes;
using Domain.Shared.Utils;

namespace Application.Handlers.Clientes
{
    public class BuscarClienteHandler : IBuscarClienteHandler
    {
        private readonly IClientesRepository _clientesRepository;

        public BuscarClienteHandler(IClientesRepository clientesRepositorio)
        {
            _clientesRepository = clientesRepositorio ?? throw new ArgumentNullException(nameof(clientesRepositorio));
        }

        public async Task<ValueResult<Cliente>> BuscarClientePorDocumento(string documento)
        {
            try
            {
                var cliente = await _clientesRepository.BuscarClientePorDocumento(documento);

                return cliente != null 
                    ? ValueResult<Cliente>.Success(cliente) 
                    : ValueResult<Cliente>.Failure("Cliente não encontrado");
            }
            catch (Exception ex)
            {
                return ValueResult<Cliente>.Failure($"Erro ao buscar Cliente: {ex.Message}");
            }
        }
    }
}
