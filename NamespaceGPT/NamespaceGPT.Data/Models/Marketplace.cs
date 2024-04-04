using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.Models
{
    public class Marketplace
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;

        public string Websiteurl { get; set; } = string.Empty;

        public string CountryOfOrigin { get; set; } = string.Empty;
    }
}
