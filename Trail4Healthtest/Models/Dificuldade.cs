using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trail4Healthtest.Models
{
    public partial class Dificuldade
    {
        public Dificuldade()
        {
            Trilho = new HashSet<Trilho>();
        }

        public int DificuldadeId { get; set; }
        [Required(ErrorMessage = "Introduza um nome para caracterizar")]
        [RegularExpression(@"\w{5,20}", ErrorMessage = "Só é aceitavel caracteres alfabeticos, minimo 5 ")]
        public string Nomedificuldade { get; set; }
        [Required(ErrorMessage = "Introduza uma caracterização da dificuldade")]
        [RegularExpression(@"\w{5,20}", ErrorMessage = "Só é aceitavel caracteres alfabeticos, minimo 5 ")]
        public string Observacoes { get; set; }

        public ICollection<Trilho> Trilho { get; set; }
    }
}
