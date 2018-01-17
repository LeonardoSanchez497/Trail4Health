using System;
using System.Collections.Generic;

namespace Trail4Healthtest.Models
{
    public partial class Trilho
    {
        public Trilho()
        {
            AgendaTuristaTrilho = new HashSet<AgendaTuristaTrilho>();
            Comentarios = new HashSet<Comentarios>();
            EstadoTrilho = new HashSet<EstadoTrilho>();
            EtapaTrilho = new HashSet<EtapaTrilho>();
            Newsletter = new HashSet<Newsletter>();
        }

        public int TrilhoId { get; set; }
        public bool Ativo { get; set; }
        public int Coddesnivel { get; set; }
        public int Coddificuldade { get; set; }
        public int Codepocaaconselhda { get; set; }
        public string Distanciaapercorrer { get; set; }
        public string Duracaomedia { get; set; }
        public string Locfim { get; set; }
        public string Locinicio { get; set; }
        public bool NewsletterAtiva { get; set; }
        public string Nometrilho { get; set; }

        public Desnivel CoddesnivelNavigation { get; set; }
        public Dificuldade CoddificuldadeNavigation { get; set; }
        public EpocaAconcelhada CodepocaaconselhdaNavigation { get; set; }
        public ICollection<AgendaTuristaTrilho> AgendaTuristaTrilho { get; set; }
        public ICollection<Comentarios> Comentarios { get; set; }
        public ICollection<EstadoTrilho> EstadoTrilho { get; set; }
        public ICollection<EtapaTrilho> EtapaTrilho { get; set; }
        public ICollection<Newsletter> Newsletter { get; set; }
    }
}
