using Domain.Integracao.Clientes;
using Domain.Shared.Utils;

namespace Application.Handlers.Clientes
{
    public class BuscarClienteHandler : IBuscarClienteHandler
    {
        private readonly IClientesRepositorio _clientesRepositorio;

        public BuscarClienteHandler(IClientesRepositorio clientesRepositorio)
        {
            _clientesRepositorio = clientesRepositorio ?? throw new ArgumentNullException(nameof(clientesRepositorio));
        }

        public async Task<ValueResult<Cliente>> BuscarClientePorDocumento(string documento)
        {
            try
            {
                var cliente = await _clientesRepositorio.BuscarClientePorDocumento(documento);

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
