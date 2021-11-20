using Hahn.ApplicatonProcess.July2021.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Hahn.ApplicatonProcess.July2021.Domain
{
    public class AppContext:DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
           
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        
    }
}
