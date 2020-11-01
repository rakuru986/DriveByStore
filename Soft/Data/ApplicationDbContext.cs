using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models.Context;
using Models.Data;

namespace Soft.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<UserData>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions, IHttpContextAccessor hca) : base(options, operationalStoreOptions)
        {
            httpContextAccessor = hca;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            StoreDbContext.InitializeTables(builder);
        }
    }
}
