using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicenseGeneratorApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LicenseGeneratorApi.Data
{
    public class LicenseDbContext : DbContext
    {
        public LicenseDbContext(DbContextOptions<LicenseDbContext> options)
            :base(options)
        {

        }
        public DbSet<License> ProductLicenses { get; set; }
    }
}
