using Domain.Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class RepositorioBase<Entity> : IRepositorioBase<Entity> where Entity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public IUnitOfWork UnitOfWork => _unitOfWork;
        public DbSet<Entity> Entidade { get; }

        public RepositorioBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            Entidade = _unitOfWork.SetEntity<Entity>();
        }

        public async Task<Entity> ObterPorId(int id)
        {
            return await Entidade.FindAsync(id);
        }

        public async Task<IEnumerable<Entity>> Listar()
        {
            return await Task.FromResult(Entidade.AsNoTracking());
        }

        public async Task<IEnumerable<Entity>> Listar
            (Expression<Func<Entity, bool>> filter, params Expression<Func<Entity, object>>[] includes)
        {
            IQueryable<Entity> query = GetQueryableWithIncludes(includes);
            query = query.Where(filter);

            return await Task.FromResult(query);
        }

        public async Task<Entity> Obter
            (Expression<Func<Entity, bool>> expression, params Expression<Func<Entity, object>>[] includes)
        {
            IQueryable<Entity> query = GetQueryableWithIncludes(includes);

            return await query.FirstOrDefaultAsync(expression);
        }

        public async Task Adicionar(Entity model)
        {
            await Entidade.AddAsync(model);
        }

        public async Task Adicionar(IEnumerable<Entity> model)
        {
            await Entidade.AddRangeAsync(model);
        }

        public async Task Atualizar(Entity model)
        {
            await Task.Run(() =>
            {
                _unitOfWork.SetEntityModified(model);
                Entidade.Update(model);
            });
        }

        public async Task Remover(Entity model)
        {
            await Task.Run(() =>
            {
                Entidade.Remove(model);
            });
        }

        private IQueryable<Entity> GetQueryableWithIncludes(params Expression<Func<Entity, object>>[] includes)
        {
            IQueryable<Entity> query = Entidade.AsQueryable<Entity>();
            return includes.Aggregate(query, (current, include) => current.Include(include));
        }

        public async Task<int> Contar(Expression<Func<Entity, bool>> filter = null)
        {
            if (filter == null)
                return await Entidade.CountAsync();

            return await Entidade.CountAsync(filter);
        }
    }
}
