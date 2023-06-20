﻿// <auto-generated />
using System;
using Meu_Treino.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Meu_Treino.Migrations
{
    [DbContext(typeof(MeuTreinoContext))]
    partial class MeuTreinoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Meu_Treino.Models.Dtos.Exercicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Equipamentos")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("GrupoMuscular")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Instrucoes")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("NivelDificuldade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__Exercici__3214EC27E04C740B");

                    b.ToTable("Exercicios");
                });

            modelBuilder.Entity("Meu_Treino.Models.Dtos.ExerciciosPlano", b =>
                {
                    b.Property<int?>("ExercicioId")
                        .HasColumnType("int")
                        .HasColumnName("ExercicioID");

                    b.Property<int?>("PlanoId")
                        .HasColumnType("int")
                        .HasColumnName("PlanoID");

                    b.Property<int>("Repeticoes")
                        .HasColumnType("int");

                    b.Property<int>("Series")
                        .HasColumnType("int");

                    b.HasIndex("ExercicioId");

                    b.HasIndex("PlanoId");

                    b.ToTable("ExerciciosPlano", (string)null);
                });

            modelBuilder.Entity("Meu_Treino.Models.Dtos.Favorito", b =>
                {
                    b.Property<int?>("ExercicioId")
                        .HasColumnType("int")
                        .HasColumnName("ExercicioID");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    b.HasIndex("ExercicioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Favoritos");
                });

            modelBuilder.Entity("Meu_Treino.Models.Dtos.Feedback", b =>
                {
                    b.Property<int?>("Avaliacao")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Feedback", (string)null);
                });

            modelBuilder.Entity("Meu_Treino.Models.Dtos.Perfi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NivelCondicionamento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Objetivos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RestricoesMedicas")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    b.HasKey("Id")
                        .HasName("PK__Perfis__3214EC27BD1C03A6");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Perfis");
                });

            modelBuilder.Entity("Meu_Treino.Models.Dtos.PlanosTreino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomePlano")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    b.HasKey("Id")
                        .HasName("PK__PlanosTr__3214EC2736468F63");

                    b.HasIndex("UsuarioId");

                    b.ToTable("PlanosTreino", (string)null);
                });

            modelBuilder.Entity("Meu_Treino.Models.Dtos.Progresso", b =>
                {
                    b.Property<string>("MedidasCorporais")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<decimal?>("Peso")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Progresso", (string)null);
                });

            modelBuilder.Entity("Meu_Treino.Models.Dtos.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Genero")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__Usuarios__3214EC275AFBF297");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Meu_Treino.Models.Dtos.ExerciciosPlano", b =>
                {
                    b.HasOne("Meu_Treino.Models.Dtos.Exercicio", "Exercicio")
                        .WithMany()
                        .HasForeignKey("ExercicioId")
                        .HasConstraintName("FK__Exercicio__Exerc__412EB0B6");

                    b.HasOne("Meu_Treino.Models.Dtos.PlanosTreino", "Plano")
                        .WithMany()
                        .HasForeignKey("PlanoId")
                        .HasConstraintName("FK__Exercicio__Plano__403A8C7D");

                    b.Navigation("Exercicio");

                    b.Navigation("Plano");
                });

            modelBuilder.Entity("Meu_Treino.Models.Dtos.Favorito", b =>
                {
                    b.HasOne("Meu_Treino.Models.Dtos.Exercicio", "Exercicio")
                        .WithMany()
                        .HasForeignKey("ExercicioId")
                        .HasConstraintName("FK__Favoritos__Exerc__47DBAE45");

                    b.HasOne("Meu_Treino.Models.Dtos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK__Favoritos__Usuar__46E78A0C");

                    b.Navigation("Exercicio");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Meu_Treino.Models.Dtos.Feedback", b =>
                {
                    b.HasOne("Meu_Treino.Models.Dtos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK__Feedback__Usuari__4316F928");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Meu_Treino.Models.Dtos.Perfi", b =>
                {
                    b.HasOne("Meu_Treino.Models.Dtos.Usuario", "Usuario")
                        .WithMany("Perfis")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK__Perfis__UsuarioI__398D8EEE");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Meu_Treino.Models.Dtos.PlanosTreino", b =>
                {
                    b.HasOne("Meu_Treino.Models.Dtos.Usuario", "Usuario")
                        .WithMany("PlanosTreinos")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK__PlanosTre__Usuar__3E52440B");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Meu_Treino.Models.Dtos.Progresso", b =>
                {
                    b.HasOne("Meu_Treino.Models.Dtos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK__Progresso__Usuar__44FF419A");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Meu_Treino.Models.Dtos.Usuario", b =>
                {
                    b.Navigation("Perfis");

                    b.Navigation("PlanosTreinos");
                });
#pragma warning restore 612, 618
        }
    }
}