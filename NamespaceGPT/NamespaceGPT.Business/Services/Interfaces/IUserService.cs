using NamespaceGPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Business.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUser();
    }
}
