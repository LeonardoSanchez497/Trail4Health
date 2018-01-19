using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trail4Healthtest.Models
{
    public partial class Trilho
    {
        public Trilho()
        {
            AgendaTuristaTrilho = new HashSet<AgendaTuristaTrilho>();
            Comentarios = new HashSet<Comentarios>();
            EstadoTrilho = new HashSet<EstadoTrilho>();
            EtapaTrilho = new HashSet<EtapaTrilho>();
            Newsletter = new HashSet<Newsletter>();
        }

        public int TrilhoId { get; set; }
        public bool Ativo { get; set; }
        public int Coddesnivel { get; set; }
        public int Coddificuldade { get; set; }
        public int Codepocaaconselhda { get; set; }
        [Required (ErrorMessage ="Por favor insera um distancia entre o 1km até 9km")]
        [RegularExpression(@"\d{1}", ErrorMessage = "Distância excedida, só pode ter no máximo 9 Km")]
        public string Distanciaapercorrer { get; set; }
        [Required(ErrorMessage = "Por favor insera uma duração até 9 horas")]
        [RegularExpression(@"\d{1}", ErrorMessage = "Duração excedida, só pode ter no máximo 9 horas")]
        public string Duracaomedia { get; set; }
        public string Locfim { get; set; }
        public string Locinicio { get; set; }
        public bool NewsletterAtiva { get; set; }
        [Required(ErrorMessage = "Introduza um nome para caracterizar a trilho")]
        [RegularExpression(@"\w{5,150}", ErrorMessage = "Só é aceitavel caracteres alfabeticos, minimo 5 ")]
        public string Nometrilho { get; set; }

        public Desnivel CoddesnivelNavigation { get; set; }
        public Dificuldade CoddificuldadeNavigation { get; set; }
        public EpocaAconcelhada CodepocaaconselhdaNavigation { get; set; }
        public ICollection<AgendaTuristaTrilho> AgendaTuristaTrilho { get; set; }
        public ICollection<Comentarios> Comentarios { get; set; }
        public ICollection<EstadoTrilho> EstadoTrilho { get; set; }
        public ICollection<EtapaTrilho> EtapaTrilho { get; set; }
        public ICollection<Newsletter> Newsletter { get; set; }
    }
}
