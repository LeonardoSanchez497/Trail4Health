using System;
using System.Collections.Generic;

namespace Trail4Healthtest.Models
{
    public partial class Estado
    {
        public Estado()
        {
            EstadoTrilho = new HashSet<EstadoTrilho>();
        }

        public int EstadoId { get; set; }
        public string Nomeestado { get; set; }

        public ICollection<EstadoTrilho> EstadoTrilho { get; set; }
    }
}
