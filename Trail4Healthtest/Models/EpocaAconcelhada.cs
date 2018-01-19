using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trail4Healthtest.Models
{
    public partial class EpocaAconcelhada
    {
        public EpocaAconcelhada()
        {
            Trilho = new HashSet<Trilho>();
        }

        public int EpocaId { get; set; }
        [Required(ErrorMessage = "Introduza um nome para caracterizar a etapa")]
        [RegularExpression(@"\w{5,20}", ErrorMessage = "Só é aceitavel caracteres alfabeticos, minimo 5 ")]
        public string Nomeepoca { get; set; }

        public ICollection<Trilho> Trilho { get; set; }
    }
}
