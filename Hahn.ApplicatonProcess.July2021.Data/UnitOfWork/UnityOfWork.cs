using Hahn.ApplicatonProcess.July2021.Data.Interfaces;
using System;
using AppContext = Hahn.ApplicatonProcess.July2021.Domain.AppContext;

namespace Hahn.ApplicatonProcess.July2021.Data.UnitOfWork
{
    public class UnityOfWork : IUnitOfWork
    {
        private readonly AppContext _context;

        public IUserRepository Users => throw new NotImplementedException();

        public IAssetRepository Assets => throw new NotImplementedException();

        public UnityOfWork(AppContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        
    }
}
