using Hahn.ApplicatonProcess.July2021.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.Interfaces
{
    public interface IAssetRepository 
    {
        Task<Asset> GetById(string id);
        Task Delete(string id);
        Task Update(Asset newBook);
        Task<Asset> Create(Asset newBook);
        Task<ICollection<Asset>> GetAll(User user);
    }
}
