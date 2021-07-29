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
        Task<T> Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<IList<T>> List(Expression<Func<T, bool>> expression = null,
                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                            List<string> includes = null);


        Task<T> GetById(int id);

    }
}
