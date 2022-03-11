using Prueba_BG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_BG.Interfaces
{
    public interface UsurInterface
    {
        Task<List<UserModel>> Get_user_list(string change, UserQuery parameter);
        Task<Response> Post_usuario(string change, UserModel parameter);
    }
}
