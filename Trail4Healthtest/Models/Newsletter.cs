using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trail4Healthtest.Models
{
    public partial class Newsletter
    {
        public int NewletterId { get; set; }

        [Display(Name = "Data Criação")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = false)]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }

        [StringLength(5000)]
        public string Descricao { get; set; }
        public byte Foto { get; set; }
        public int? TrilhoId { get; set; }

        public Trilho Trilho { get; set; }
    }
}
