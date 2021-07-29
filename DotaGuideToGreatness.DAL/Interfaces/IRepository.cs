using DotaGuideToGreatness.Domain;
using DotaGuideToGreatness.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.DAL.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<Result<T>> Add(T entity);
        Task<Result> AddRange(IEnumerable<T> entities);


        Result DeleteEntity(T entity);
        Task<Result> DeleteById(long id);

        Result Update(T entity);

        Task<Result<T>> GetById(int id);
        Task<Result<IList<T>>> List(Expression<Func<T, bool>> expression = null,
                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                            List<string> includes = null);
    }
}
