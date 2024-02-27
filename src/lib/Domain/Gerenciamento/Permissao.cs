namespace Domain.Gerenciamento
{
    public class Permissao
    {
        public int Id { get; set; }
        public int IdRecurso { get; set; }
        public int IdPerfil { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual Recurso Recurso { get; set; }
    }
}
