using Microsoft.EntityFrameworkCore;

namespace Domain.Shared.Repositories
{
    public interface IUnitOfWork
    {
        Task CommitChanges();
        void BegintTransaction();
        Task CommitTransaction();
        void Rollback();
        DbSet<Entity> SetEntity<Entity>() where Entity : class;
        void SetEntityModified<Entity>(Entity entity);
    }
}
