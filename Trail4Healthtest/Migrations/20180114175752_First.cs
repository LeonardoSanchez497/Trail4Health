using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Trail4Healthtest.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    nomedesnivel = table.Column<string>(nullable: true),
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
                    nomedificuldade = table.Column<string>(nullable: true),
                    Observacoes = table.Column<string>(nullable: true)
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
                    nomeepoca = table.Column<string>(nullable: true)
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
                    nomeestado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.estadoId);
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
                    nomeetapa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapa", x => x.etapaId);
                });

            migrationBuilder.CreateTable(
                name: "Turista",
                columns: table => new
                {
                    turistaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    contatoemergencia = table.Column<string>(nullable: true),
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
                name: "Trilho",
                columns: table => new
                {
                    trilhoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ativo = table.Column<int>(nullable: false),
                    coddesnivel = table.Column<int>(nullable: false),
                    coddificuldade = table.Column<int>(nullable: false),
                    codepocaaconselhda = table.Column<int>(nullable: false),
                    distanciaapercorrer = table.Column<string>(nullable: true),
                    duracaomedia = table.Column<string>(nullable: true),
                    locfim = table.Column<string>(nullable: true),
                    locinicio = table.Column<string>(nullable: true),
                    newsletterAtiva = table.Column<bool>(nullable: false),
                    nometrilho = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilho", x => x.trilhoId);
                    table.ForeignKey(
                        name: "FK_Trilho_Desnivel",
                        column: x => x.coddesnivel,
                        principalTable: "Desnivel",
                        principalColumn: "desnivelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trilho_Dificuldade",
                        column: x => x.coddificuldade,
                        principalTable: "Dificuldade",
                        principalColumn: "dificuldadeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trilho_EpocaAconselhada",
                        column: x => x.codepocaaconselhda,
                        principalTable: "EpocaAconcelhada",
                        principalColumn: "epocaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgendaTuristaTrilho",
                columns: table => new
                {
                    agendaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    datafim = table.Column<DateTime>(type: "datetime", nullable: true),
                    datainicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    estadoagendado = table.Column<string>(maxLength: 150, nullable: true),
                    tempogasto = table.Column<string>(maxLength: 150, nullable: true),
                    trilhoid = table.Column<int>(nullable: false),
                    turistaid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaTuristaTrilho", x => x.agendaId);
                    table.ForeignKey(
                        name: "FK_AgendaTuristaTrilho_Trilho",
                        column: x => x.trilhoid,
                        principalTable: "Trilho",
                        principalColumn: "trilhoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgendaTuristaTrilho_Turista",
                        column: x => x.turistaid,
                        principalTable: "Turista",
                        principalColumn: "turistaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    comentarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    avaliacaoId = table.Column<int>(nullable: false),
                    comentar = table.Column<string>(nullable: true),
                    Completou = table.Column<string>(nullable: true),
                    duracaoTrilho = table.Column<string>(nullable: true),
                    trilhoId = table.Column<int>(nullable: false),
                    turistaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.comentarioId);
                    table.ForeignKey(
                        name: "FK_Comentarios_Avaliacao",
                        column: x => x.avaliacaoId,
                        principalTable: "Avaliacao",
                        principalColumn: "avaliacaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Trilho",
                        column: x => x.trilhoId,
                        principalTable: "Trilho",
                        principalColumn: "trilhoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentarios_Turista",
                        column: x => x.turistaId,
                        principalTable: "Turista",
                        principalColumn: "turistaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstadoTrilho",
                columns: table => new
                {
                    estadoTrilhoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    causa = table.Column<string>(nullable: true),
                    datafim = table.Column<DateTime>(nullable: false),
                    datainicio = table.Column<DateTime>(nullable: false),
                    estadoId = table.Column<int>(nullable: false),
                    trilhoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoTrilho", x => x.estadoTrilhoId);
                    table.ForeignKey(
                        name: "FK_EstadoTrilho_Estado",
                        column: x => x.estadoId,
                        principalTable: "Estado",
                        principalColumn: "estadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EstadoTrilho_Trilho",
                        column: x => x.trilhoId,
                        principalTable: "Trilho",
                        principalColumn: "trilhoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EtapaTrilho",
                columns: table => new
                {
                    etapatrilhoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: true),
                    etapaid = table.Column<int>(nullable: false),
                    ordem_etapa = table.Column<string>(maxLength: 150, nullable: true),
                    trilhoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapaTrilho", x => x.etapatrilhoId);
                    table.ForeignKey(
                        name: "FK_EtapaTrilho_Etapa",
                        column: x => x.etapaid,
                        principalTable: "Etapa",
                        principalColumn: "etapaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EtapaTrilho_Trilho",
                        column: x => x.trilhoId,
                        principalTable: "Trilho",
                        principalColumn: "trilhoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Newsletter",
                columns: table => new
                {
                    newletterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    foto = table.Column<byte>(nullable: false),
                    trilhoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletter", x => x.newletterId);
                    table.ForeignKey(
                        name: "FK_Newsletter_Trilho",
                        column: x => x.trilhoId,
                        principalTable: "Trilho",
                        principalColumn: "trilhoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendaTuristaTrilho_trilhoid",
                table: "AgendaTuristaTrilho",
                column: "trilhoid");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaTuristaTrilho_turistaid",
                table: "AgendaTuristaTrilho",
                column: "turistaid");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_avaliacaoId",
                table: "Comentarios",
                column: "avaliacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_trilhoId",
                table: "Comentarios",
                column: "trilhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_turistaId",
                table: "Comentarios",
                column: "turistaId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoTrilho_estadoId",
                table: "EstadoTrilho",
                column: "estadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoTrilho_trilhoId",
                table: "EstadoTrilho",
                column: "trilhoId");

            migrationBuilder.CreateIndex(
                name: "IX_EtapaTrilho_etapaid",
                table: "EtapaTrilho",
                column: "etapaid");

            migrationBuilder.CreateIndex(
                name: "IX_EtapaTrilho_trilhoId",
                table: "EtapaTrilho",
                column: "trilhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Newsletter_trilhoId",
                table: "Newsletter",
                column: "trilhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Trilho_coddesnivel",
                table: "Trilho",
                column: "coddesnivel");

            migrationBuilder.CreateIndex(
                name: "IX_Trilho_coddificuldade",
                table: "Trilho",
                column: "coddificuldade");

            migrationBuilder.CreateIndex(
                name: "IX_Trilho_codepocaaconselhda",
                table: "Trilho",
                column: "codepocaaconselhda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaTuristaTrilho");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "EstadoTrilho");

            migrationBuilder.DropTable(
                name: "EtapaTrilho");

            migrationBuilder.DropTable(
                name: "Newsletter");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Turista");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Etapa");

            migrationBuilder.DropTable(
                name: "Trilho");

            migrationBuilder.DropTable(
                name: "Desnivel");

            migrationBuilder.DropTable(
                name: "Dificuldade");

            migrationBuilder.DropTable(
                name: "EpocaAconcelhada");
        }
    }
}
