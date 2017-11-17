using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trail4Health.Models
{
    public class Comment
    {
        //Comentar
        [Required (ErrorMessage = "Please enter your comment")]
        public string comentario { get; set; }

        [Required(ErrorMessage = "Please enter your Name")]
        public string nome { get; set; }
        [Required(ErrorMessage = "Please enter Trilho Name ")]
        public string nometrilho { get; set; }

        [Required (ErrorMessage ="Please enter if you finish or not")]
        public bool? completou { get; set; }
        
        [Required (ErrorMessage ="Please enter time spend on Trilho")]
        public string tempo { get; set; }
        [Required (ErrorMessage ="Please enter your motive to quit")]
        public string motivo { get; set; }
    }
}
