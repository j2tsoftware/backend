namespace Domain.Integracao.AtualizacaoCliente
{
    public class AtualizacaoCliente
    {
        public BlocoControle BlocoDeControle { get; set; }
        public IEnumerable<AtualizacaoPessoa> Pessoas { get; set; }
        public int QuantidadeOperacao { get; set; }
        public DateTime DataMovimentacao { get; set; }

        public AtualizacaoCliente()
        {
            BlocoDeControle = new BlocoControle
            {
                NomeArquivo = "ACCS001",
                IdentificadorDestinatario = 1,
                IdentificadorEmissor = 1,
                NumeroRemessaArquivo = Pessoas != null && Pessoas.Any() ? Pessoas.Count() : 0
            };
        }
    }
}
