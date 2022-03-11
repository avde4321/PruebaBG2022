using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_BG.Model
{
    public class UserModel
    {
        public string id_user { get; set; }
        public string id_persona { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string cargo { get; set; }
        public string fech_creacion { get; set; }
    }

    public class UserQuery
    {
        public string id_user { get; set; }
        public string id_persona { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string cargo { get; set; }
        public string fech_creacion { get; set; }
    }
}
