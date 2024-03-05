namespace Domain.Integracao.AtualizacoesRelacionamentos
{
    internal static class AtualizacaoRelacionamentoClienteFactory
    {
        public static IEnumerable<AtualizacaoRelacionamentoCliente> CriarListaDeClientesPorRequisicao(
            AtualizacaoRelacionamentoRequest requisicao)
        {
            if (requisicao == null || requisicao.Clientes == null)
                return Enumerable.Empty<AtualizacaoRelacionamentoCliente>();

            return requisicao.Clientes.Select(x => new AtualizacaoRelacionamentoCliente
            {
                DataInicioRelacionamento = x.DataInicioRelacionamento,
                DataFimRelacionamento = x.DataFimRelacionamento,
                Documento = x.Documento,
                QualificadorOperacao = x.QualificadorOperacao,
                TipoOperacao = x.TipoOperacao
            });
        }
    }
}
