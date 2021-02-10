using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LicenseGeneratorApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LicenseGeneratorApi.Bootstrap
{
    public static class PrepareDatabase
    {
        
        public static void Init(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LicenseDbContext>();
                Console.WriteLine(dbContext.Database.GetConnectionString());
                Thread.Sleep(30000);
                dbContext.Database.Migrate();
            }
        }
    }
}
