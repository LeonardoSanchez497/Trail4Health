using System;
using System.Collections.Generic;

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
        public string Contatoemergencia { get; set; }
        public string Email { get; set; }
        public int Nif { get; set; }
        public string Nome { get; set; }
        public string NumeroTelefone { get; set; }
        public bool EstadoTurista { get; set; }

        public ICollection<AgendaTuristaTrilho> AgendaTuristaTrilho { get; set; }
        public ICollection<Comentarios> Comentarios { get; set; }
    }
}
