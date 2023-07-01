using System;
using System.Collections.Generic;
using Meu_Treino.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Meu_Treino.Data;

public partial class MeuTreinoContext : DbContext
{
    public MeuTreinoContext()
    {

    }

    public MeuTreinoContext(DbContextOptions<MeuTreinoContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Exercicio> Exercicios { get; set; }

    public virtual DbSet<ExerciciosPlano> ExerciciosPlanos { get; set; }

    public virtual DbSet<Favorito> Favoritos { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Perfi> Perfis { get; set; }

    public virtual DbSet<PlanosTreino> PlanosTreinos { get; set; }

    public virtual DbSet<Progresso> Progressos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=MeuTreino;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exercici__3214EC27E04C740B");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).IsUnicode(false);
            entity.Property(e => e.Equipamentos).IsUnicode(false);
            entity.Property(e => e.GrupoMuscular)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Instrucoes).IsUnicode(false);
            entity.Property(e => e.NivelDificuldade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ExerciciosPlano>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("ExerciciosPlano");

            entity.Property(e => e.ExercicioId).HasColumnName("ExercicioID");
            entity.Property(e => e.PlanoId).HasColumnName("PlanoID");

            entity.HasOne(d => d.Exercicio).WithMany()
                .HasForeignKey(d => d.ExercicioId)
                .HasConstraintName("FK__Exercicio__Exerc__412EB0B6");

            entity.HasOne(d => d.Plano).WithMany()
                .HasForeignKey(d => d.PlanoId)
                .HasConstraintName("FK__Exercicio__Plano__403A8C7D");
        });


        modelBuilder.Entity<Favorito>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ExercicioId).HasColumnName("ExercicioID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Exercicio).WithMany()
                .HasForeignKey(d => d.ExercicioId)
                .HasConstraintName("FK__Favoritos__Exerc__47DBAE45");

            entity.HasOne(d => d.Usuario).WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Favoritos__Usuar__46E78A0C");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Feedback");

            entity.Property(e => e.Comentario).IsUnicode(false);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Feedback__Usuari__4316F928");
        });

        modelBuilder.Entity<Perfi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Perfis__3214EC27BD1C03A6");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NivelCondicionamento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Objetivos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RestricoesMedicas).IsUnicode(false);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Perfis)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Perfis__UsuarioI__398D8EEE");
        });

        modelBuilder.Entity<PlanosTreino>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlanosTr__3214EC2736468F63");

            entity.ToTable("PlanosTreino");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NomePlano)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.PlanosTreinos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__PlanosTre__Usuar__3E52440B");
        });

        modelBuilder.Entity<Progresso>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Progresso");

            entity.Property(e => e.MedidasCorporais).IsUnicode(false);
            entity.Property(e => e.Peso).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Progresso__Usuar__44FF419A");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC275AFBF297");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DataNascimento).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
