using System;
using System.Collections.Generic;

namespace Trail4Healthtest.Models
{
    public partial class Avaliacao
    {
        public Avaliacao()
        {
            Comentarios = new HashSet<Comentarios>();
        }

        public int AvaliacaoId { get; set; }
        public string Classificacao { get; set; }

        public ICollection<Comentarios> Comentarios { get; set; }
    }
}
