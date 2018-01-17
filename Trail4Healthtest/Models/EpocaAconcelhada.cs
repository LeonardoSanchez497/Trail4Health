using System;
using System.Collections.Generic;

namespace Trail4Healthtest.Models
{
    public partial class EpocaAconcelhada
    {
        public EpocaAconcelhada()
        {
            Trilho = new HashSet<Trilho>();
        }

        public int EpocaId { get; set; }
        public string Nomeepoca { get; set; }

        public ICollection<Trilho> Trilho { get; set; }
    }
}
