using DotaGuideToGreatness.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.DAL.Implementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed;
        private DotaDbContext _dbContext;
        private readonly Func<DotaDbContext> _instanceFunc;

        public DotaDbContext DbContext => _dbContext ??= _instanceFunc.Invoke();

        public UnitOfWork(Func<DotaDbContext> dbContextFactory)
        {
            _instanceFunc = dbContextFactory;
        }


        public async Task<bool> CommitAsync()
        {
            return await DbContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            if(_disposed == false && _dbContext != null)
            {
                _disposed = true;
                _dbContext.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
