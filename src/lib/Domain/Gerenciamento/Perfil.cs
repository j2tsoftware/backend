namespace Domain.Gerenciamento
{
    public class Perfil
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Permissao> Permissoes { get; set; }
    }
}
