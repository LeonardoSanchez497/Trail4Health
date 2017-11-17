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
    }
}
