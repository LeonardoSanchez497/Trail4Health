using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trail4Healthtest.Models
{
    public partial class Turista
    {
        public Turista()
        {
            AgendaTuristaTrilho = new HashSet<AgendaTuristaTrilho>();
            Comentarios = new HashSet<Comentarios>();
        }

        public int TuristaId { get; set; }
        [Required(ErrorMessage = "Introduza um contacto em caso de emergencia, Esse número é invalido")]
        [RegularExpression(@"(2\d{8})|9[1236]\d{7}", ErrorMessage = "Só é aceitavel caracteres numéricos, minimo 9")]
        public string Contatoemergencia { get; set; }
        public string Email { get; set; }
        public int Nif { get; set; }
        [Required(ErrorMessage = "Introduza seu nome ")]
        [RegularExpression(@"\w{3,150}", ErrorMessage = "Só é aceitavel caracteres alfabeticos ")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Introduza um contacto, Esse número é invalido")]
        [RegularExpression(@"(2\d{8})|9[1236]\d{7}", ErrorMessage = "Só é aceitavel caracteres numéricos, minimo 9")]
        public string NumeroTelefone { get; set; }
        [Required(ErrorMessage = "Introduza um nome para caracterizar a trilho")]
        [RegularExpression(@"\w{5,150}", ErrorMessage = "Só é aceitavel caracteres alfabeticos, minimo 5 ")]
        public bool EstadoTurista { get; set; }

        public ICollection<AgendaTuristaTrilho> AgendaTuristaTrilho { get; set; }
        public ICollection<Comentarios> Comentarios { get; set; }
    }
}
