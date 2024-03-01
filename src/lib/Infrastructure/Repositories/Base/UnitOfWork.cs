using Domain.Shared.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DatabaseContext Contexto { get; set; }
        private IDbContextTransaction Transaction { get; set; }

        public UnitOfWork(DatabaseContext context)
        {
            Contexto = context;
        }

        public async Task CommitChanges()
        {
            try
            {
                await Contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                throw new InvalidOperationException("Erro ao salvar dados. " + message);
            }
        }

        public void BegintTransaction()
        {
            Transaction = Contexto.Database.BeginTransaction();
        }

        public async Task CommitTransaction()
        {
            await CommitChanges();
            Contexto.Database.CommitTransaction();
            DisposeTransaction();
        }

        public void Rollback()
        {
            if (Transaction != null)
            {
                Contexto.Database.RollbackTransaction();
                Transaction.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            DisposeTransaction();
            Contexto = null;
        }

        private void DisposeTransaction()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
                Transaction = null;
            }
        }
    }
}
