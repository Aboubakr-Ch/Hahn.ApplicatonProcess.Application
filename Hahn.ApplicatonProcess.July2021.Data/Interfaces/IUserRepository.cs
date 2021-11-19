

using Hahn.ApplicatonProcess.July2021.Domain.Models;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task Delete(int id);
        Task Update(User user);
        Task<User> Create(User user);
    }
}
