using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trail4Healthtest.Models
{
    public class Trilho
    {
        public int trilhoId { get; set; } //PK
        public string distancia_a_percorrer { get; set; }
        public string duracao_media { get; set; }
        public string loc_inicio { get; set; }
        public string loc_fim { get; set; }
        public int cod_dificuldade { get; set; } //FK
        public int cod_desnivel { get; set; } //FK
        public int cod_etapa_aconselhada { get; set; } //FK
        public int ativo { get; set; } //FK
    }
}
