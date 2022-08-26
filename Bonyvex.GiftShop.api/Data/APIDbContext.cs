
using Bonyvex.GiftShop.api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Bonyvex.GiftShop.api.Data
{
    public class APIDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public APIDbContext(DbContextOptions<APIDbContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }

        public DbSet<ProductModel> Products { get; set; }       
        public DbSet<PurchaseModel> Purchases { get; set; }

        public IDbConnection CreateConnection()
        => new SqlConnection(_config.GetConnectionString("Connection"));

    }
}
