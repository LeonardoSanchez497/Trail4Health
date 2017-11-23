using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trail4Healthtest.Models
{
    public class Turista
    {
        public int turistaId { get; set; } //Pk
        public string nome { get; set; }
        public string numeroTelefone { get; set; }
        public int nif { get; set; }
        public string email { get; set; }
        public string contato_emergencia { get; set; }
    }
}
