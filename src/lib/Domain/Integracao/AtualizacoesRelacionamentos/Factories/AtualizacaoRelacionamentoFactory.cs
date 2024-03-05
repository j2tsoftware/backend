using Domain.Shared.Utils;

namespace Domain.Integracao.AtualizacoesRelacionamentos
{
    public static class AtualizacaoRelacionamentoFactory
    {
        public static ValueResult<AtualizacaoRelacionamento> CriarPorRequisicao(
            AtualizacaoRelacionamentoRequest requisicao, int numeroRemessa)
        {
            var clientes = AtualizacaoRelacionamentoClienteFactory.CriarListaDeClientesPorRequisicao(requisicao);
            var atualizacaoRelacionamento = new AtualizacaoRelacionamento(clientes, numeroRemessa);

            return atualizacaoRelacionamento.DadosValidos
                ? ValueResult<AtualizacaoRelacionamento>.Success(atualizacaoRelacionamento)
                : ValueResult<AtualizacaoRelacionamento>.Failure(atualizacaoRelacionamento.Falhas);
        }
    }
}
