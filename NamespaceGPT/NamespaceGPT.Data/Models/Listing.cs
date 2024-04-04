using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.Models
{
    public class Listing
    {
        public int Id { get; set; } = 0;
        public int ProductId { get; set; } = 0;

        public int MarketplaceId { get; set; } = 0;

        public float Price { get; set; } = 0;
    }
}
