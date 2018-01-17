using System;
using System.Collections.Generic;

namespace Trail4Healthtest.Models
{
    public partial class Dificuldade
    {
        public Dificuldade()
        {
            Trilho = new HashSet<Trilho>();
        }

        public int DificuldadeId { get; set; }
        public string Nomedificuldade { get; set; }
        public string Observacoes { get; set; }

        public ICollection<Trilho> Trilho { get; set; }
    }
}
