using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Trail4Healthtest.Migrations
{
    public partial class correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgendaTuristaTrilho_EstadoTrilho_estadoagendado",
                table: "AgendaTuristaTrilho");

            migrationBuilder.DropIndex(
                name: "IX_AgendaTuristaTrilho_estadoagendado",
                table: "AgendaTuristaTrilho");

            migrationBuilder.DropColumn(
                name: "estadoagendado",
                table: "AgendaTuristaTrilho");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "estadoagendado",
                table: "AgendaTuristaTrilho",
                maxLength: 150,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AgendaTuristaTrilho_estadoagendado",
                table: "AgendaTuristaTrilho",
                column: "estadoagendado");

            migrationBuilder.AddForeignKey(
                name: "FK_AgendaTuristaTrilho_EstadoTrilho_estadoagendado",
                table: "AgendaTuristaTrilho",
                column: "estadoagendado",
                principalTable: "EstadoTrilho",
                principalColumn: "estadoTrilhoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
