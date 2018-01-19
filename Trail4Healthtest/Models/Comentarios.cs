using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trail4Healthtest.Models
{
    public partial class Comentarios
    {
        public int ComentarioId { get; set; }
        public int AvaliacaoId { get; set; }
        [Required(ErrorMessage = "Necessário inserir um comentário")]
        [RegularExpression(@"\d\w{10,500}", ErrorMessage = "Só é aceitavel caracteres alfanumericos, minimo 10 ")]
        public string Comentar { get; set; }
        public string Completou { get; set; }
        [RegularExpression(@"\d{1}", ErrorMessage = "Duração excedida, só pode ter no máximo 9 horas")]
        public string DuracaoTrilho { get; set; }
        public int TrilhoId { get; set; }
        public int TuristaId { get; set; }

        public Avaliacao Avaliacao { get; set; }
        public Trilho Trilho { get; set; }
        public Turista Turista { get; set; }
    }
}
