using texim.Data.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using texim.Data;
using texim.Data.DAL;
using Microsoft.EntityFrameworkCore;

namespace texim.Data.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public string ErrorMassage { get; set; } = string.Empty;

        private readonly IUnitOfWork _unitOfWork;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(context);
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public void Delete(T t)
        {
            if (_context.Set<T>() == null)
            {
                ErrorMassage = "The item you trying to Delete is not in Database";
                throw new ArgumentException(nameof(t));
            }

            _context.Set<T>().Remove(t);
            _unitOfWork.Commit();
        }


        public async Task<int> DeleteAsync(T t)
        {
            if (_context.Set<T>() == null)
            {
                ErrorMassage = "The item you trying to Delete is not in Database";
                throw new ArgumentException(nameof(t));
            }

            _context.Set<T>().Remove(t);
            return await _unitOfWork.CommitAsync();
        }
        public bool Exist(Expression<Func<T, bool>> predicate)
        {
            var exist = _context.Set<T>().Where(predicate);
            return exist.Any();
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int? page = null, int? pageSize = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            return query.ToList();
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().SingleOrDefault(match);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match).ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(match);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
      
        public T GetById(int? id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

    
        public T Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        public async Task<T> InsertAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }
        public void Update(T updated)
        {
            if (_context.Set<T>() == null)
            {
                ErrorMassage = "No Database detected";
                throw new ArgumentNullException(nameof(updated));
            }
            _context.Set<T>().Attach(updated);
            _context.Entry(updated).State = EntityState.Modified;
            _unitOfWork.Commit();
        }

        public async Task<T> UpdateAsync(T updated)
        {
            if (updated == null)
            {
                return null;
            }
            _context.Set<T>().Attach(updated);
            _context.Entry(updated).State = EntityState.Modified;

            await _unitOfWork.CommitAsync();
            return updated;
        }

        public IList<T> GetRoles()
        {
          return  _context.Set<T>().ToList();
        }

       
        public IQueryable<T> GetRoleByUser(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

     
    }
}