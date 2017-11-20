using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trail4Health.Models
{
    public class Newsletter
    {
        [Required(ErrorMessage = " Enviar mail para:")]
        public string Para { get; set; }

        [Required(ErrorMessage = " Introduza um assunto")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = " Introduza uma mensagem")]
        public string Mensagem { get; set; }

        [Required(ErrorMessage = " submeter")]
        public bool? Enviar { get; set; }
    }
}

