using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trail4Healthtest.Models;

namespace Trail4Healthtest.Data
{
    public class SeedData
    {
        public async static Task SeedCountries(Trails4HealthContext context)
        {
            if (!context.Avaliacao.Any())
            {
                var ava = new List<Avaliacao>
            {
                new Avaliacao { Classificacao = "Muito mau"},
                new Avaliacao { Classificacao = "Mau" },
                new Avaliacao { Classificacao = "Bom" },
                new Avaliacao { Classificacao = "Otimo" },
                new Avaliacao { Classificacao = "Excelente" }

            };
                context.AddRange(ava);
                await context.SaveChangesAsync();
            }

            if (!context.Desnivel.Any())
            {
                var desnivel = new List<Desnivel>
            {
               new Desnivel { Nomedesnivel = "Plano", Observacoes="0%" },
               new Desnivel { Nomedesnivel = "Variável", Observacoes="6%" },
               new Desnivel { Nomedesnivel = "Ingreme", Observacoes="12%" },
               new Desnivel { Nomedesnivel = "Acentuado", Observacoes="18%" }

            };
                context.AddRange(desnivel);
                await context.SaveChangesAsync();
            }

            if (!context.Dificuldade.Any())
            {
                var dificuldade = new List<Dificuldade>
            {
                new Dificuldade { Nomedificuldade="Fácil", Observacoes="Sem objeção nenhum"},
                new Dificuldade { Nomedificuldade="Normal", Observacoes="Sem objeção nenhuma"},
                new Dificuldade { Nomedificuldade="Díficl", Observacoes="Pessoas com dificuldades não fazer"}

            };
                context.AddRange(dificuldade);
                await context.SaveChangesAsync();
            }

            if (!context.EpocaAconcelhada.Any())
            {
                var epoca = new List<EpocaAconcelhada>
            {
                new EpocaAconcelhada {Nomeepoca="Primavera"},
                new EpocaAconcelhada {Nomeepoca="Verão"},
                new EpocaAconcelhada {Nomeepoca="Outono"},
                new EpocaAconcelhada {Nomeepoca="Inverno"},
                new EpocaAconcelhada {Nomeepoca="Todas"}
            };
                context.AddRange(epoca);
                await context.SaveChangesAsync();
            }

            if (!context.Estado.Any())
            {
                var estado = new List<Estado>
            {
                new Estado {Nomeestado="Aberto"},
                new Estado {Nomeestado="Fechado"},
                new Estado {Nomeestado="Em Manutenção"}

            };
                context.AddRange(estado);
                await context.SaveChangesAsync();
            }

            if (!context.Trilho.Any())
            {

                var trilho = new List<Trilho>
                {

                    new Trilho { Ativo=true, Coddesnivel=5,  Coddificuldade=4, Codepocaaconselhda=6, Distanciaapercorrer="5km", Duracaomedia="5horas", Locfim="Serra", Locinicio="Serra", NewsletterAtiva=true, Nometrilho="Alberto" },
                };

                context.AddRange(trilho);
                await context.SaveChangesAsync();
            }

        }
    }
}
