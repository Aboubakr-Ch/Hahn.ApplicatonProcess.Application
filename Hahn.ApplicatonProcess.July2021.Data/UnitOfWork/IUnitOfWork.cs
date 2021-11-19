using Hahn.ApplicatonProcess.July2021.Data.BusinessLogic;
using Hahn.ApplicatonProcess.July2021.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IAssetRepository Assets { get; }
        int Complete();
    }
}
