using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Trail4Health.Models
{
    public class Newsletter
    {
        
        public string Data { get;  }

        [Required(ErrorMessage = " Assunto")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = " Mensagem")]
        public string Mensagem { get; set; }

        [Required(ErrorMessage = " Foto")]
        public string Foto { get; set; }

        [Required(ErrorMessage = " Comentarios")]
        public string Comentarios { get; set; }

        [Required(ErrorMessage = " Guardar")]
        public bool? Guardar { get; set; }

        [Required(ErrorMessage = " Enviar")]
        public bool? Enviar { get; set; }

        public string Email { get; set; }


    }
}

