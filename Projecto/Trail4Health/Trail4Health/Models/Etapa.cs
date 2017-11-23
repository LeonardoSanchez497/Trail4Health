using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trail4Healthtest.Models
{
    public class Etapa
    {
        public int etapaId { get; set; } //PK
        public string nome_etapa { get; set; }
        public string geolocalizacao { get; set; }
        public string duracao { get; set; }
        public string distancia { get; set; }
    }
}
