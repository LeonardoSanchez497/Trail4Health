using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Trail4Health.Models
{
    public class EmailFormModel
    {
        [Required , Display (Name="Nome Turista")]
        public string FromName { get; set; }

        [Required, Display (Name ="Email"), EmailAddress]
        public string FromEmail { get; set; }

        [Required]
        public string message { get; set; }
    }
}
