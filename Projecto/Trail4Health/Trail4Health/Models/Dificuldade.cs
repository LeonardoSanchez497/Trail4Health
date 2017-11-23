using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trail4Healthtest.Models
{
    public class Dificuldade
    {
        public int dificuldadeId { get; set; } //PK
        public string nome_dificuldade { get; set; }
        public string Observacoes { get; set; } 
    }
}
