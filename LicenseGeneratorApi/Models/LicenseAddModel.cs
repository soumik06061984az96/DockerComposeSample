using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseGeneratorApi.Models
{
    public class LicenseAddModel
    {
        public string ProductName { get; set; }
        public string ProductVersion { get; set; }
    }
}
