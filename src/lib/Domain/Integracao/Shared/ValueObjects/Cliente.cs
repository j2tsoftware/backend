namespace Domain.Integracao.Shared
{
    public class Cliente
    {
        public int Documento { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
