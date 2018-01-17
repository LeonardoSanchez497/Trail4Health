using System;
using System.Collections.Generic;

namespace Trail4Healthtest.Models
{
    public partial class Etapa
    {
        public Etapa()
        {
            EtapaTrilho = new HashSet<EtapaTrilho>();
        }

        public int EtapaId { get; set; }
        public string Distancia { get; set; }
        public string Duracao { get; set; }
        public string Geolocalizacao { get; set; }
        public string Nomeetapa { get; set; }

        public ICollection<EtapaTrilho> EtapaTrilho { get; set; }
    }
}
