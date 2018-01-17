using System;
using System.Collections.Generic;

namespace Trail4Healthtest.Models
{
    public partial class Newsletter
    {
        public int NewletterId { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public byte Foto { get; set; }
        public int? TrilhoId { get; set; }

        public Trilho Trilho { get; set; }
    }
}
