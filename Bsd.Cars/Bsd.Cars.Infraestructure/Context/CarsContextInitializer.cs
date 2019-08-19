using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bsd.Cars.Infraestructure.Context
{
    public static class CarsContextInitializer
    {
        public static void Initialize(CarsContext context)
        {
            RunMigrations(context);
        }

        private static void RunMigrations(DbContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
}
