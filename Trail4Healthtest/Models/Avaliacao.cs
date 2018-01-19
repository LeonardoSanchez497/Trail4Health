using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trail4Healthtest.Models
{
    public partial class Avaliacao
    {
        public Avaliacao()
        {
            Comentarios = new HashSet<Comentarios>();
        }

        public int AvaliacaoId { get; set; }
        [Required (ErrorMessage ="Necessário inserir uma classificação")]
        [RegularExpression (@"\w{3,20}", ErrorMessage="Só é aceitavel caracteres alfabeticos e minimo tres caracteres")]
        public string Classificacao { get; set; }

        public ICollection<Comentarios> Comentarios { get; set; }
    }
}
