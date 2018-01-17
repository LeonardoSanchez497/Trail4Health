using System;
using System.Collections.Generic;

namespace Trail4Healthtest.Models
{
    public partial class EstadoTrilho
    {
        public int EstadoTrilhoId { get; set; }
        public string Causa { get; set; }
        public DateTime Datafim { get; set; }
        public DateTime Datainicio { get; set; }
        public int EstadoId { get; set; }
        public int TrilhoId { get; set; }

        public Estado Estado { get; set; }
        public Trilho Trilho { get; set; }
    }
}
