namespace Domain.Integracao.Shared
{
    public class BlocoControle
    {
        public int IdentificadorEmissor { get; set; }
        public int IdentificadorDestinatario { get; set; }
        public string NomeArquivo { get; set; }
        public int NumeroRemessaArquivo { get; set; }

        public BlocoControle(string nomeArquivo, int numeroRemessa)
        {
            NomeArquivo = nomeArquivo;
            NumeroRemessaArquivo = numeroRemessa;
            IdentificadorEmissor = Constants.Emissor;
            IdentificadorDestinatario = Constants.Destinatario;
        }
    }
}