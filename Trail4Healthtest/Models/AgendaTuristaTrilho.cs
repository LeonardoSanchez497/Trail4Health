using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trail4Healthtest.Models
{
    public partial class AgendaTuristaTrilho
    {
        public int AgendaId { get; set; }
        public DateTime? Datainicio { get; set; }
        public DateTime? Datafim { get; set; }

        [RegularExpression (@"\d{1}",ErrorMessage ="Duração excedida, só pode ter no máximo 9 horas")]
        public string Tempogasto { get; set; }
        public int Trilhoid { get; set; }
        public int Turistaid { get; set; }

        public Trilho Trilho { get; set; }
        public Turista Turista { get; set; }
    }
}
