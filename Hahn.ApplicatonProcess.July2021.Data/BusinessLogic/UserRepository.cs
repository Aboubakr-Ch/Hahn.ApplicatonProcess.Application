using Hahn.ApplicatonProcess.July2021.Data.Interfaces;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.BusinessLogic
{
    public class UserRepository : IUserRepository
    {
        private readonly Domain.AppContext _context;

        public UserRepository(Domain.AppContext context) 
        {
          _context = context;
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            if (user.Assets != null)
            {
                _context.Assets.AddRange(user.Assets);
            }
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user.Assets != null)
            {
                var list = _context.Assets.Where(x => x.UserId == id).ToList();
                foreach (var asset in list)
                {
                    user.Assets.Add(asset);
                }
            }
            return user;
        }

        public async Task Update(User user)
        {
            if (user.Assets != null)
            {
                _context.Assets.AddRange(user.Assets);
            }
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
