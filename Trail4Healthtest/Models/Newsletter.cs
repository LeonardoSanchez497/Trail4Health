using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trail4Healthtest.Models
{
    public class Newsletter
    {
        public int newletterId { get; set; } //Pk
        public DateTime data { get; set; }
        public string descricao { get; set; }
        public Byte foto { get; set; } //array de bytes

    }
}
