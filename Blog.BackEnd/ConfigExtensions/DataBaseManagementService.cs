

using API.Blog.BackEnd.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace API.Blog.BackEnd.ConfigExtensions
{
    public static class DataBaseManagementService
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider
                    .GetService<Context2>();
                serviceDb.Database.Migrate();
            }
        }
    }
}
