using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trail4Healthtest.Models
{
    public partial class Etapa
    {
        public Etapa()
        {
            EtapaTrilho = new HashSet<EtapaTrilho>();
        }

        public int EtapaId { get; set; }
        [Required (ErrorMessage ="Desculpa,Não podemos andar tanto")]
        [RegularExpression(@"\d{1}", ErrorMessage = "Distancia excedida, só pode ter no máximo 9 Km")]
        public string Distancia { get; set; }
        [Required (ErrorMessage ="Precisa de ser inserido uma duração prevista")]
        [RegularExpression(@"\d{1}", ErrorMessage = "Duração excedida, só pode ter no máximo 9 horas")]
        public string Duracao { get; set; }
        public string Geolocalizacao { get; set; }
        [Required(ErrorMessage = "Introduza um nome para a etapa")]
        [RegularExpression(@"\w{5,20}", ErrorMessage = "Só é aceitavel caracteres alfabeticos, minimo 5 ")]
        public string Nomeetapa { get; set; }

        public ICollection<EtapaTrilho> EtapaTrilho { get; set; }
    }
}
