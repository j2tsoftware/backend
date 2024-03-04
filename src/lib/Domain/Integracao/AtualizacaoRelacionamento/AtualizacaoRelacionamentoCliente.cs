namespace Domain.Integracao.AtualizacaoCliente
{
    public class AtualizacaoRelacionamentoCliente
    {
        public Guid Id { get; set; }
        public string Documento { get; set; }
        public char TipoOperacao { get; set; }
        public char QualificadorOperacao { get; set; }
        public Guid AtualizacaoRelacionamentoId { get; set; }
    }
}
