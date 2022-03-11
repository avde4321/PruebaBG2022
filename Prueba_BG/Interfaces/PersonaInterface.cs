using Prueba_BG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_BG.Interfaces
{
    public interface PersonaInterface
    {
        Task<List<PersonaModel>> Get_person_list(string change, PersonaQuery parameter);
        Task<Response> Post_person(string change, PersonaModel parameter);
    }
}
