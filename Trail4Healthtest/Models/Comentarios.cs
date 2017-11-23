using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trail4Healthtest.Models
{
    public class Comentarios
    {
        public int comentarioId { get; set; }//PK
        public int turistaId { get; set; }//FK
        public int trilhoId { get; set; } //FK
        public string duracaoTrilho { get; set; }
        public string avaliacao { get; set; }
        public string comentar { get; set; }

        public Turista turista { get; set; }

    }
}
