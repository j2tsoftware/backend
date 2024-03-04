namespace Domain.Integracao.AtualizacaoRelacionamento
{
    public class AtualizacaoRelacionamentoClienteRequest
    {
        public string Documento { get; set; }
        public char TipoOperacao { get; set; }
        public char QualificadorOperacao { get; set; }
        public DateTime DataInicioRelacionamento { get; set; }
        public DateTime? DataFimRelacionamento { get; set; }
    }
}
