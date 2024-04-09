using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.Models
{
    public class NewProductAlert : IAlert
    {
        public int Id {  get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }

        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}
