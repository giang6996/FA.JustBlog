using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core
{
	public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly JustBlogDbContext _dbContext;
        protected readonly DbSet<T> _entitySet;

        public GenericRepository(JustBlogDbContext dbContext)
        {
            _dbContext = dbContext;
            _entitySet = _dbContext.Set<T>();
        }

        public T Find(int id)
        {
            return _entitySet.Find(id);
        }

        public void Add(T entity)
        {
            _entitySet.Add(entity);
        }

        public void Update(T entity)
        {
            _entitySet.Update(entity);
        }

        public void Delete(T entity)
        {
            _entitySet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = _entitySet.Find(id);
            if (entity != null)
            {
                _entitySet.Remove(entity);
            } else
            {
                throw new EntityNotFoundException($"Entity with ID {id} not found.");
            }
        }

        public IList<T> GetAll()
        {
            return _entitySet.ToList();
        }
    }
}
