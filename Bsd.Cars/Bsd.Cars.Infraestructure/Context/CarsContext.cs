using Bsd.Cars.Domain.Orders;
using Bsd.Cars.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bsd.Cars.Infraestructure.Context
{
    public class CarsContext : DbContext, IUnitOfWork
    {
        public DbSet<Order> Orders { get; set; }

        public CarsContext(DbContextOptions options) : base(options) { }

        public static CarsContext Create(string connectionString)
        {
            var options = new DbContextOptionsBuilder().UseSqlServer(
                connectionString,
                o => o.UseNetTopologySuite())
                .Options;
            return new CarsContext(options);
        }
        public async Task Save()
        {
            if (ChangeTracker.HasChanges())
            {
                await SaveChangesAsync();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ModelConfigurations.Orders.OrderEntityConfiguration());
        }
    }
}
