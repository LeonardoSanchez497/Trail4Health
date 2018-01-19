using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trail4Healthtest.Models
{
    public partial class Estado
    {
        public Estado()
        {
            EstadoTrilho = new HashSet<EstadoTrilho>();
        }

        public int EstadoId { get; set; }
        [Required(ErrorMessage = "Introduza um nome para caracterizar o estado")]
        [RegularExpression(@"\w{5,20}", ErrorMessage = "Só é aceitavel caracteres alfabeticos, minimo 5 ")]
        public string Nomeestado { get; set; }

        public ICollection<EstadoTrilho> EstadoTrilho { get; set; }
    }
}
