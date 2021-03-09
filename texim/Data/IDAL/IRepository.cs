using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace texim.Data.IDAL
{
    public interface IRepository<T> where T : class 
    {

      
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        //return object table data by it's id
        T GetById(int? id);
        Task<T> GetByIdAsync(int? id);

        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> match);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> match);

        T Insert(T entity);
        Task<T> InsertAsync(T entity);

        void Update(T updated);
        Task<T> UpdateAsync(T updated);

        void Delete(T t);
        Task<int> DeleteAsync(T t);

        int Count();
        Task<int> CountAsync();

        IEnumerable<T> Filter(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            int? page = null,
            int? pageSize = null);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        bool Exist(Expression<Func<T, bool>> predicate);

        IList<T> GetRoles();

        IQueryable<T> GetRoleByUser(Expression<Func<T, bool>> predicate);


    }
}
