using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trail4Healthtest.Models
{
    
    public partial class Desnivel
    {  
        public Desnivel()
        {
            Trilho = new HashSet<Trilho>();
        }

        public int DesnivelId { get; set; }
        [Required (ErrorMessage ="Introduza um nome para caracterizar")]
        [RegularExpression(@"\w{5,20}", ErrorMessage = "Só é aceitavel caracteres alfabeticos, minimo 5 ")]
        public string Nomedesnivel { get; set; }
        [Required (ErrorMessage ="Coloque um valor percentual para o desnivel ex: 10%")]
        [RegularExpression(@"\d+%{1,2}", ErrorMessage = "Desnivel excedido, só pode ter no máximo 99")]
        public string Observacoes { get; set; }

        public ICollection<Trilho> Trilho { get; set; }
    }
}
