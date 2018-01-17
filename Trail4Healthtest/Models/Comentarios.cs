using System;
using System.Collections.Generic;

namespace Trail4Healthtest.Models
{
    public partial class Comentarios
    {
        public int ComentarioId { get; set; }
        public int AvaliacaoId { get; set; }
        public string Comentar { get; set; }
        public string Completou { get; set; }
        public string DuracaoTrilho { get; set; }
        public int TrilhoId { get; set; }
        public int TuristaId { get; set; }

        public Avaliacao Avaliacao { get; set; }
        public Trilho Trilho { get; set; }
        public Turista Turista { get; set; }
    }
}
