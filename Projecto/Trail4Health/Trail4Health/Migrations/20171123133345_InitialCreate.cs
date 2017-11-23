using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Trail4Healthtest.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    trilhoId = table.Column<int>(nullable: false),
                    turistaId = table.Column<int>(nullable: false),
                    data_fim = table.Column<DateTime>(nullable: false),
                    data_inicio = table.Column<DateTime>(nullable: false),
                    estado_agendado = table.Column<string>(nullable: true),
                    tempo_gasto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => new { x.trilhoId, x.turistaId });
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    avaliacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    classificacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.avaliacaoId);
                });

            migrationBuilder.CreateTable(
                name: "Desnivel",
                columns: table => new
                {
                    desnivelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome_desnivel = table.Column<string>(nullable: true),
                    observacoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desnivel", x => x.desnivelId);
                });

            migrationBuilder.CreateTable(
                name: "Dificuldade",
                columns: table => new
                {
                    dificuldadeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Observacoes = table.Column<string>(nullable: true),
                    nome_dificuldade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dificuldade", x => x.dificuldadeId);
                });

            migrationBuilder.CreateTable(
                name: "EpocaAconcelhada",
                columns: table => new
                {
                    epocaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome_epoca = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpocaAconcelhada", x => x.epocaId);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    estadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome_estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.estadoId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoTrilho",
                columns: table => new
                {
                    estadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    causa = table.Column<string>(nullable: true),
                    data_fim = table.Column<DateTime>(nullable: false),
                    data_inicio = table.Column<DateTime>(nullable: false),
                    estadoTrilhoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoTrilho", x => x.estadoId);
                });

            migrationBuilder.CreateTable(
                name: "Etapa",
                columns: table => new
                {
                    etapaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    distancia = table.Column<string>(nullable: true),
                    duracao = table.Column<string>(nullable: true),
                    geolocalizacao = table.Column<string>(nullable: true),
                    nome_etapa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapa", x => x.etapaId);
                });

            migrationBuilder.CreateTable(
                name: "Newsletter",
                columns: table => new
                {
                    newletterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    foto = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletter", x => x.newletterId);
                });

            migrationBuilder.CreateTable(
                name: "Trilho",
                columns: table => new
                {
                    trilhoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ativo = table.Column<int>(nullable: false),
                    cod_desnivel = table.Column<int>(nullable: false),
                    cod_dificuldade = table.Column<int>(nullable: false),
                    cod_etapa_aconselhada = table.Column<int>(nullable: false),
                    distancia_a_percorrer = table.Column<string>(nullable: true),
                    duracao_media = table.Column<string>(nullable: true),
                    loc_fim = table.Column<string>(nullable: true),
                    loc_inicio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilho", x => x.trilhoId);
                });

            migrationBuilder.CreateTable(
                name: "Turista",
                columns: table => new
                {
                    turistaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    contato_emergencia = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    nif = table.Column<int>(nullable: false),
                    nome = table.Column<string>(nullable: true),
                    numeroTelefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turista", x => x.turistaId);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    comentarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    avaliacao = table.Column<string>(nullable: true),
                    comentar = table.Column<string>(nullable: true),
                    duracaoTrilho = table.Column<string>(nullable: true),
                    trilhoId = table.Column<int>(nullable: false),
                    turistaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.comentarioId);
                    table.ForeignKey(
                        name: "FK_Comentarios_Turista_turistaId",
                        column: x => x.turistaId,
                        principalTable: "Turista",
                        principalColumn: "turistaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_turistaId",
                table: "Comentarios",
                column: "turistaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Desnivel");

            migrationBuilder.DropTable(
                name: "Dificuldade");

            migrationBuilder.DropTable(
                name: "EpocaAconcelhada");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "EstadoTrilho");

            migrationBuilder.DropTable(
                name: "Etapa");

            migrationBuilder.DropTable(
                name: "Newsletter");

            migrationBuilder.DropTable(
                name: "Trilho");

            migrationBuilder.DropTable(
                name: "Turista");
        }
    }
}
