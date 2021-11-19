using Microsoft.EntityFrameworkCore;



namespace Hahn.ApplicatonProcess.July2021.Data.RepositoryPattern
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity GetById(int id)
        {
           return _context.Set<TEntity>().Find(id);
        }

        public void Post(TEntity entity)
        {
           _context.Set<TEntity>().Add(entity);
        }

        public void Put(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
