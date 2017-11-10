using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trail4Health.Models
{
    public class RegTurista
    {
        //Nome do turista
        [Required(ErrorMessage = "Please enter the Name")]
        public string Name { get; set;} 

        //Data Nascimento
        [Required (ErrorMessage = "Please enter you birthday ")]
        public string Birthday { get; set; }

        //Email
        [Required (ErrorMessage ="Please enter you email")]
        public string Email { get; set; }

        //Telefone/telemovel
        [Required (ErrorMessage ="Please enter your phone number")]
        public int Phonenumeber { get; set; }

        //Contato de emergencia
        [Required (ErrorMessage ="Please enter you emergency phone number")]
        public int EPhonenumber { get; set; }



    }
}
