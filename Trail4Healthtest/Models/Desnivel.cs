using System;
using System.Collections.Generic;

namespace Trail4Healthtest.Models
{
    public partial class Desnivel
    {
        public Desnivel()
        {
            Trilho = new HashSet<Trilho>();
        }

        public int DesnivelId { get; set; }
        public string Nomedesnivel { get; set; }
        public string Observacoes { get; set; }

        public ICollection<Trilho> Trilho { get; set; }
    }
}
