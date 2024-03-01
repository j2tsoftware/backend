namespace Domain.Integracao.Clientes
{
    public class Cliente
    {
        public int Id { get; set; }
        public int Documento { get; set; }
        public string Nome { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
