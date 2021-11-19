using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.RepositoryPattern
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        void Post(TEntity entity);
        void Delete(TEntity entity);
        void Put(TEntity entity);
    }
}
