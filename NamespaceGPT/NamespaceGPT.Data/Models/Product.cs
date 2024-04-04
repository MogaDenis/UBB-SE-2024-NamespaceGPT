using System;
using System.Collections.Generic;

namespace NamespaceGPT.Data.Models
{
    public class Product
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public IEnumerable<string> Attributes { get; set; } = new List<string>();
    }
}
