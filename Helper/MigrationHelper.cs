using Microsoft.EntityFrameworkCore;
using urlShortener;
using urlShortener.DbContextClass;

namespace urlShortener.Helper
{
    public static class MigrationHelper
    {
        public static void ApplyMigrations(this WebApplication web)
        {
            using var scope = web.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
