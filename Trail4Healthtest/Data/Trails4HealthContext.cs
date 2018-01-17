using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Trail4Healthtest.Models
{
    public partial class Trails4HealthContext : DbContext
    {
        public virtual DbSet<AgendaTuristaTrilho> AgendaTuristaTrilho { get; set; }
        public virtual DbSet<Avaliacao> Avaliacao { get; set; }
        public virtual DbSet<Comentarios> Comentarios { get; set; }
        public virtual DbSet<Desnivel> Desnivel { get; set; }
        public virtual DbSet<Dificuldade> Dificuldade { get; set; }
        public virtual DbSet<EpocaAconcelhada> EpocaAconcelhada { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<EstadoTrilho> EstadoTrilho { get; set; }
        public virtual DbSet<Etapa> Etapa { get; set; }
        public virtual DbSet<EtapaTrilho> EtapaTrilho { get; set; }
        public virtual DbSet<Newsletter> Newsletter { get; set; }
        public virtual DbSet<Trilho> Trilho { get; set; }
        public virtual DbSet<Turista> Turista { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Trails4Health;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendaTuristaTrilho>(entity =>
            {
                entity.HasKey(e => e.AgendaId);

                entity.HasIndex(e => e.Trilhoid);

                entity.HasIndex(e => e.Turistaid);

                entity.Property(e => e.AgendaId).HasColumnName("agendaId");

                entity.Property(e => e.Datafim)
                    .HasColumnName("datafim")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datainicio)
                    .HasColumnName("datainicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tempogasto)
                    .HasColumnName("tempogasto")
                    .HasMaxLength(150);

                entity.Property(e => e.Trilhoid).HasColumnName("trilhoid");

                entity.Property(e => e.Turistaid).HasColumnName("turistaid");

                entity.HasOne(d => d.Trilho)
                    .WithMany(p => p.AgendaTuristaTrilho)
                    .HasForeignKey(d => d.Trilhoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AgendaTuristaTrilho_Trilho");

                entity.HasOne(d => d.Turista)
                    .WithMany(p => p.AgendaTuristaTrilho)
                    .HasForeignKey(d => d.Turistaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AgendaTuristaTrilho_Turista");
            });

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.Property(e => e.AvaliacaoId).HasColumnName("avaliacaoId");

                entity.Property(e => e.Classificacao).HasColumnName("classificacao");
            });

            modelBuilder.Entity<Comentarios>(entity =>
            {
                entity.HasKey(e => e.ComentarioId);

                entity.HasIndex(e => e.AvaliacaoId);

                entity.HasIndex(e => e.TrilhoId);

                entity.HasIndex(e => e.TuristaId);

                entity.Property(e => e.ComentarioId).HasColumnName("comentarioId");

                entity.Property(e => e.AvaliacaoId).HasColumnName("avaliacaoId");

                entity.Property(e => e.Comentar).HasColumnName("comentar");

                entity.Property(e => e.DuracaoTrilho).HasColumnName("duracaoTrilho");

                entity.Property(e => e.TrilhoId).HasColumnName("trilhoId");

                entity.Property(e => e.TuristaId).HasColumnName("turistaId");

                entity.HasOne(d => d.Avaliacao)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.AvaliacaoId)
                    .HasConstraintName("FK_Comentarios_Avaliacao");

                entity.HasOne(d => d.Trilho)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.TrilhoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comentarios_Trilho");

                entity.HasOne(d => d.Turista)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.TuristaId)
                    .HasConstraintName("FK_Comentarios_Turista");
            });

            modelBuilder.Entity<Desnivel>(entity =>
            {
                entity.Property(e => e.DesnivelId).HasColumnName("desnivelId");

                entity.Property(e => e.Nomedesnivel).HasColumnName("nomedesnivel");

                entity.Property(e => e.Observacoes).HasColumnName("observacoes");
            });

            modelBuilder.Entity<Dificuldade>(entity =>
            {
                entity.Property(e => e.DificuldadeId).HasColumnName("dificuldadeId");

                entity.Property(e => e.Nomedificuldade).HasColumnName("nomedificuldade");
            });

            modelBuilder.Entity<EpocaAconcelhada>(entity =>
            {
                entity.HasKey(e => e.EpocaId);

                entity.Property(e => e.EpocaId).HasColumnName("epocaId");

                entity.Property(e => e.Nomeepoca).HasColumnName("nomeepoca");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.EstadoId).HasColumnName("estadoId");

                entity.Property(e => e.Nomeestado).HasColumnName("nomeestado");
            });

            modelBuilder.Entity<EstadoTrilho>(entity =>
            {
                entity.HasIndex(e => e.EstadoId);

                entity.HasIndex(e => e.TrilhoId);

                entity.Property(e => e.EstadoTrilhoId).HasColumnName("estadoTrilhoId");

                entity.Property(e => e.Causa).HasColumnName("causa");

                entity.Property(e => e.Datafim).HasColumnName("datafim");

                entity.Property(e => e.Datainicio).HasColumnName("datainicio");

                entity.Property(e => e.EstadoId).HasColumnName("estadoId");

                entity.Property(e => e.TrilhoId).HasColumnName("trilhoId");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.EstadoTrilho)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EstadoTrilho_Estado");

                entity.HasOne(d => d.Trilho)
                    .WithMany(p => p.EstadoTrilho)
                    .HasForeignKey(d => d.TrilhoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EstadoTrilho_Trilho");
            });

            modelBuilder.Entity<Etapa>(entity =>
            {
                entity.Property(e => e.EtapaId).HasColumnName("etapaId");

                entity.Property(e => e.Distancia).HasColumnName("distancia");

                entity.Property(e => e.Duracao).HasColumnName("duracao");

                entity.Property(e => e.Geolocalizacao).HasColumnName("geolocalizacao");

                entity.Property(e => e.Nomeetapa).HasColumnName("nomeetapa");
            });

            modelBuilder.Entity<EtapaTrilho>(entity =>
            {
                entity.HasIndex(e => e.Etapaid);

                entity.HasIndex(e => e.TrilhoId);

                entity.Property(e => e.EtapatrilhoId).HasColumnName("etapatrilhoId");

                entity.Property(e => e.Etapaid).HasColumnName("etapaid");

                entity.Property(e => e.OrdemEtapa)
                    .HasColumnName("ordem_etapa")
                    .HasMaxLength(150);

                entity.Property(e => e.TrilhoId).HasColumnName("trilhoId");

                entity.HasOne(d => d.Etapa)
                    .WithMany(p => p.EtapaTrilho)
                    .HasForeignKey(d => d.Etapaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EtapaTrilho_Etapa");

                entity.HasOne(d => d.Trilho)
                    .WithMany(p => p.EtapaTrilho)
                    .HasForeignKey(d => d.TrilhoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EtapaTrilho_Trilho");
            });

            modelBuilder.Entity<Newsletter>(entity =>
            {
                entity.HasKey(e => e.NewletterId);

                entity.HasIndex(e => e.TrilhoId);

                entity.Property(e => e.NewletterId).HasColumnName("newletterId");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Descricao).HasColumnName("descricao");

                entity.Property(e => e.Foto).HasColumnName("foto");

                entity.Property(e => e.TrilhoId).HasColumnName("trilhoId");

                entity.HasOne(d => d.Trilho)
                    .WithMany(p => p.Newsletter)
                    .HasForeignKey(d => d.TrilhoId)
                    .HasConstraintName("FK_Newsletter_Trilho");
            });

            modelBuilder.Entity<Trilho>(entity =>
            {
                entity.HasIndex(e => e.Coddesnivel);

                entity.HasIndex(e => e.Coddificuldade);

                entity.HasIndex(e => e.Codepocaaconselhda);

                entity.Property(e => e.TrilhoId).HasColumnName("trilhoId");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Coddesnivel).HasColumnName("coddesnivel");

                entity.Property(e => e.Coddificuldade).HasColumnName("coddificuldade");

                entity.Property(e => e.Codepocaaconselhda).HasColumnName("codepocaaconselhda");

                entity.Property(e => e.Distanciaapercorrer).HasColumnName("distanciaapercorrer");

                entity.Property(e => e.Duracaomedia).HasColumnName("duracaomedia");

                entity.Property(e => e.Locfim).HasColumnName("locfim");

                entity.Property(e => e.Locinicio).HasColumnName("locinicio");

                entity.Property(e => e.NewsletterAtiva).HasColumnName("newsletterAtiva");

                entity.Property(e => e.Nometrilho).HasColumnName("nometrilho");

                entity.HasOne(d => d.CoddesnivelNavigation)
                    .WithMany(p => p.Trilho)
                    .HasForeignKey(d => d.Coddesnivel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trilho_Desnivel");

                entity.HasOne(d => d.CoddificuldadeNavigation)
                    .WithMany(p => p.Trilho)
                    .HasForeignKey(d => d.Coddificuldade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trilho_Dificuldade");

                entity.HasOne(d => d.CodepocaaconselhdaNavigation)
                    .WithMany(p => p.Trilho)
                    .HasForeignKey(d => d.Codepocaaconselhda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trilho_EpocaAconselhada");
            });

            modelBuilder.Entity<Turista>(entity =>
            {
                entity.Property(e => e.TuristaId).HasColumnName("turistaId");

                entity.Property(e => e.Contatoemergencia).HasColumnName("contatoemergencia");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Nif).HasColumnName("nif");

                entity.Property(e => e.Nome).HasColumnName("nome");

                entity.Property(e => e.NumeroTelefone).HasColumnName("numeroTelefone");
            });
        }
    }
}
