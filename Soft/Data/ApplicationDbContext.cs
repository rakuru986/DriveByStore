using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models.Context;
using Models.Data;

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
