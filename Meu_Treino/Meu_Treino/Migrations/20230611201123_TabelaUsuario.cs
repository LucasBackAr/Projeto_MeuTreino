using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meu_Treino.Migrations
{
    /// <inheritdoc />
    public partial class TabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercicios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    GrupoMuscular = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Instrucoes = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    NivelDificuldade = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Equipamentos = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Exercici__3214EC27E04C740B", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    Senha = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Genero = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__3214EC275AFBF297", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: true),
                    ExercicioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Favoritos__Exerc__47DBAE45",
                        column: x => x.ExercicioID,
                        principalTable: "Exercicios",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Favoritos__Usuar__46E78A0C",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: true),
                    Comentario = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Avaliacao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Feedback__Usuari__4316F928",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: true),
                    NivelCondicionamento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Objetivos = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RestricoesMedicas = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Perfis__3214EC27BD1C03A6", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Perfis__UsuarioI__398D8EEE",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PlanosTreino",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: true),
                    NomePlano = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PlanosTr__3214EC2736468F63", x => x.ID);
                    table.ForeignKey(
                        name: "FK__PlanosTre__Usuar__3E52440B",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Progresso",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: true),
                    Peso = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    MedidasCorporais = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Progresso__Usuar__44FF419A",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ExerciciosPlano",
                columns: table => new
                {
                    PlanoID = table.Column<int>(type: "int", nullable: true),
                    ExercicioID = table.Column<int>(type: "int", nullable: true),
                    Repeticoes = table.Column<int>(type: "int", nullable: false),
                    Series = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Exercicio__Exerc__412EB0B6",
                        column: x => x.ExercicioID,
                        principalTable: "Exercicios",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Exercicio__Plano__403A8C7D",
                        column: x => x.PlanoID,
                        principalTable: "PlanosTreino",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciciosPlano_ExercicioID",
                table: "ExerciciosPlano",
                column: "ExercicioID");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciciosPlano_PlanoID",
                table: "ExerciciosPlano",
                column: "PlanoID");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_ExercicioID",
                table: "Favoritos",
                column: "ExercicioID");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_UsuarioID",
                table: "Favoritos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UsuarioID",
                table: "Feedback",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Perfis_UsuarioID",
                table: "Perfis",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanosTreino_UsuarioID",
                table: "PlanosTreino",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Progresso_UsuarioID",
                table: "Progresso",
                column: "UsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciciosPlano");

            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropTable(
                name: "Progresso");

            migrationBuilder.DropTable(
                name: "PlanosTreino");

            migrationBuilder.DropTable(
                name: "Exercicios");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
