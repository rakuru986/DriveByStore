using Microsoft.EntityFrameworkCore;
using Models.Context;

namespace Soft.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
             : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            StoreDbContext.InitializeTables(builder);
        }
    }
}
