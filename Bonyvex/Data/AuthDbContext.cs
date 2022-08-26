using Bonyvex.Authentication.api.Models.IdentityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bonyvex.Authentication.api.Data
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public readonly IHttpContextAccessor httpContextAccessor;

        public AuthDbContext(DbContextOptions<AuthDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public DbSet<ApplicationUserTokens> ApplicationUserTokens { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
