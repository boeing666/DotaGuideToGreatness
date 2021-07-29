using DotaGuideToGreatness.DAL.Interfaces;
using DotaGuideToGreatness.Domain;
using DotaGuideToGreatness.Domain.Entities;
using DotaGuideToGreatness.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.DAL.Implementation
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private ILogger _logger;
        private readonly DotaDbContext _context;
        private DbSet<T> _dbSet;
        public DbSet<T> DbSet;

        //public DbSet<T> DbSet => _dbset ??= _context.Set<T>();
        public GenericRepository(DotaDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;

            _logger = loggerFactory.CreateLogger<GenericRepository<T>>();
            DbSet = _context.Set<T>();

        }

        public async Task<Result<T>> Add(T entity)
        {
            var addedEntity = await DbSet.AddAsync(entity);

            return Result<T>.Success(addedEntity.Entity);
        }

        public async Task<Result> AddRange(IEnumerable<T> entities)
        {
            await DbSet.AddRangeAsync(entities);

            return Result.Success();
        }

        public Result DeleteEntity(T entity)
        {
            DbSet.Remove(entity);
            return Result.Success();
        }

        public async Task<Result> DeleteById(long id)
        {
            var entity = await DbSet.FindAsync(id);

            if(entity == null)
            {
                _logger.LogError($"Couldn't Delete Entity: {typeof(T)} By Id: {id}");
                return Result.Failed(StatusCodes.NotFound);
            }

            return DeleteEntity(entity);
        }

        public Result Update(T entity)
        {
            DbSet.Update(entity);
            return Result.Success();
        }

        public async Task<Result<T>> GetById(int id)
        {
            var foundEntity = await DbSet.FindAsync(id);

            //TODO გასატესტია ესა FindAsync vs FirsOrDefault; FindAsync მუშაობს Primary Key-ზე.

            return Result<T>.Success(foundEntity);
        }

        public Task<Result<IList<T>>> List(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }
    }
}
