using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trail4Healthtest.Models
{
    public class AgendaTuristaTrilho
    {
        public int trilhoId { get; set; } //pk
        public int turistaId { get; set; } //pk
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public string tempo_gasto { get; set; }
        public string estado_agendado { get; set; }

    }
}
