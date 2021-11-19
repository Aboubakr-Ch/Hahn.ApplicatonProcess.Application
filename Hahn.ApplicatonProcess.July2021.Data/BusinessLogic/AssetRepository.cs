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
    public class AssetRepository : IAssetRepository
    {

        private readonly Domain.AppContext _context;
        public AssetRepository(Domain.AppContext context)
        {
            _context = context;
        }
        public async Task<Asset> Create(Asset newBook)
        {
            _context.Assets.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook;
        }
        public async Task Delete(string id)
        {
            var book = await _context.Assets.FindAsync(id);
            _context.Assets.Remove(book);
            await _context.SaveChangesAsync();
        }
        public async Task<Asset> GetById(string id)
        {
            return await _context.Assets.FindAsync(id);
        }
        public async Task Update(Asset newBook)
        {
            _context.Entry(newBook).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
