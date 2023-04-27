using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using EcommerceAPI.Models;

// Tools -> Manage Nuget Packages ->
namespace EcommerceAPI.Models
{
    public class EcommerceAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public EcommerceAPIDBContext(DbContextOptions<EcommerceAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //connection string --> different
            var connectionString = Configuration.GetConnectionString("EcommerceDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        }

        public DbSet<Discount> Discounts { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
    }
}

