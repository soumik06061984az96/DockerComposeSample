using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LicenseGeneratorApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicenseGeneratorApi.Models;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace LicenseGeneratorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LicenseController : ControllerBase
    {
        private readonly ILogger<LicenseController> _logger;
        private readonly LicenseDbContext _dbContext;

        public LicenseController(ILogger<LicenseController> logger, LicenseDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<License>>> Get()
        {
            var licenses = await _dbContext.ProductLicenses.ToListAsync();
            return this.StatusCode(200, licenses);
        }

        [HttpPost]
        public async Task<ActionResult<License>> Post(LicenseAddModel model)
        {
            var license = new License { 
                Key = Guid.NewGuid().ToString(),
                CreateDate = DateTime.Now,
                ProductName = model.ProductName,
                ProductVersion = model.ProductVersion
            };

            var addedLicense = await _dbContext.ProductLicenses.AddAsync(license);
            
            await _dbContext.SaveChangesAsync();


            return this.StatusCode(StatusCodes.Status201Created, addedLicense.Entity);
        }

    }
}
