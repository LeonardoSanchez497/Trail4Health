using System;
using System.Collections.Generic;

namespace Trail4Healthtest.Models
{
    public partial class EtapaTrilho
    {
        public int EtapatrilhoId { get; set; }
        public bool Ativo { get; set; }
        public int Etapaid { get; set; }
        public string OrdemEtapa { get; set; }
        public int TrilhoId { get; set; }

        public Etapa Etapa { get; set; }
        public Trilho Trilho { get; set; }
    }
}
