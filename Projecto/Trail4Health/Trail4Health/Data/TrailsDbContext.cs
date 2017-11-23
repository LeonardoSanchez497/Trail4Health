using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trail4Healthtest.Models;

namespace Trail4Healthtest.Data
{
    public class TrailsDbContext : DbContext
    {
        public TrailsDbContext(DbContextOptions<TrailsDbContext> options) : base(options)
        {
        }

        public DbSet<AgendaTuristaTrilho> Agenda { get; set; }
        public DbSet<Avaliacaocs> Avaliacao { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<Desnivel> Desnivel { get; set; }
        public DbSet<Dificuldade> Dificuldade { get; set; }
        public DbSet<epoca_aconcelhada> EpocaAconcelhada { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Estado_Trilho> EstadoTrilho { get; set; }
        public DbSet<Etapa> Etapa { get; set; }
        public DbSet<Newsletter> Newsletter { get; set; }
        public DbSet<Trilho> Trilho { get; set; }
        public DbSet<Turista> Turista { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendaTuristaTrilho>()
                           .HasKey(ag => new { ag.trilhoId, ag.turistaId });

            modelBuilder.Entity<Avaliacaocs>()
                .HasKey(av => new { av.avaliacaoId });

            modelBuilder.Entity<Comentarios>()
          .HasKey(cm => new { cm.comentarioId });

            modelBuilder.Entity<Desnivel>()
          .HasKey(dn => new { dn.desnivelId });

            modelBuilder.Entity<Dificuldade>()
                           .HasKey(df => new { df.dificuldadeId });

            modelBuilder.Entity<epoca_aconcelhada>()
                .HasKey(ea => new { ea.epocaId });

            modelBuilder.Entity<Estado>()
          .HasKey(es => new { es.estadoId });

            modelBuilder.Entity<Estado_Trilho>()
          .HasKey(et => new { et.estadoId });

            modelBuilder.Entity<Etapa>()
         .HasKey(ep => new { ep.etapaId });

            modelBuilder.Entity<Newsletter>()
         .HasKey(nw => new { nw.newletterId });

            modelBuilder.Entity<Trilho>()
         .HasKey(tr => new { tr.trilhoId });

            modelBuilder.Entity<Turista>()
         .HasKey(tu => new { tu.turistaId });

        }
    }
}
