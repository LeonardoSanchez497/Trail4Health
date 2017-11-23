using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trail4Healthtest.Models
{
    public class Estado_Trilho
    {
        public int estadoTrilhoId { get; set; } //PK
        public int estadoId { get; set; } //FK
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public string causa { get; set; }

    }
}
