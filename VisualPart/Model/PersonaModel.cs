using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisualPart.Model
{
    public class PersonaModel
    {
        public string id_persona { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
        public string direction { get; set; }
        public string fech_creacion { get; set; }
    }
    public class PersonaQuery
    {
        public string id_persona { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
        public string direction { get; set; }
        public string fech_creacion { get; set; }
    }
}
