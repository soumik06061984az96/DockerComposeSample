using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseGeneratorApi.Models
{
    public class License
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string ProductName { get; set; }
        public string ProductVersion { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
