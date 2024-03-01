namespace Domain.Integracao.Clientes
{
    public interface IAdicionarClienteHandler
    {
        Task<bool> AdicionarCliente(ClienteRequest requisicao);
    }
}
