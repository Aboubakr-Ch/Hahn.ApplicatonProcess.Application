using Hahn.ApplicatonProcess.July2021.Data.Interfaces;
using Hahn.ApplicatonProcess.July2021.Data.RepositoryPattern;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.BusinessLogic
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
