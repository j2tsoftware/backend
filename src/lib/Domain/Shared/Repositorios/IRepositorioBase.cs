using System.Linq.Expressions;

namespace Domain.Shared.Repositories
{
    public interface IRepositorioBase<Model> where Model : class
    {
        IUnitOfWork UnitOfWork { get; }
        Task<Model> ObterPorId(int id);
        Task<IEnumerable<Model>> Listar();
        Task<IEnumerable<Model>> Listar(Expression<Func<Model, bool>> filter, params Expression<Func<Model, object>>[] includes);
        Task<Model> Obter(Expression<Func<Model, bool>> expression, params Expression<Func<Model, object>>[] includes);
        Task Adicionar(Model model);
        Task Adicionar(IEnumerable<Model> model);
        Task Atualizar(Model model);
        Task Remover(Model model);
        Task<int> Contar(Expression<Func<Model, bool>> filter = null);
    }
}
