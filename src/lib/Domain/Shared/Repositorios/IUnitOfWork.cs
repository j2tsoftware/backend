namespace Domain.Shared.Repositories
{
    public interface IUnitOfWork
    {
        Task CommitChanges();
        void BegintTransaction();
        Task CommitTransaction();
        void Rollback();
    }
}
