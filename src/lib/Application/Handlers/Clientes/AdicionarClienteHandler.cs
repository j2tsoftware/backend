using Domain.Integracao.Clientes;

namespace Application.Handlers.Clientes
{
    public class AdicionarClienteHandler : IAdicionarClienteHandler
    {
        private readonly IClientesRepositorio _clientesRepositorio;

        public AdicionarClienteHandler(IClientesRepositorio clientesRepositorio)
        {
            _clientesRepositorio = clientesRepositorio ?? throw new ArgumentNullException(nameof(clientesRepositorio));
        }

        public async Task<bool> AdicionarCliente(ClienteRequest requisicao)
        {
            try
            {
                var cliente = Cliente.MapearPorRequisicao(requisicao);
                await _clientesRepositorio.AdicionarCliente(cliente);
                await _clientesRepositorio.UnitOfWork.CommitChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}