using Domain_Layer.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Contracts
{
    public interface IAuthService
    {
          Task<User> Register(string email, string password);
         Task<string> Login(string email, string password);
    }

}
