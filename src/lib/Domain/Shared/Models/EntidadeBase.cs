namespace Domain.Shared.Models
{
    public class EntidadeBase
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public EntidadeBase()
        {
            DataAtualizacao = DateTime.Now;
        }        
    }
}
