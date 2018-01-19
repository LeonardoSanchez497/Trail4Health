using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trail4Healthtest.Models
{
    public partial class EstadoTrilho
    {
        public int EstadoTrilhoId { get; set; }
        [Required(ErrorMessage = "Introduza um nome para caracterizar a causa")]
        [RegularExpression(@"\w{5,150}", ErrorMessage = "Só é aceitavel caracteres alfabeticos, minimo 5 ")]
        public string Causa { get; set; }
        public DateTime Datafim { get; set; }
        public DateTime Datainicio { get; set; }
        public int EstadoId { get; set; }
        public int TrilhoId { get; set; }

        public Estado Estado { get; set; }
        public Trilho Trilho { get; set; }
    }
}
