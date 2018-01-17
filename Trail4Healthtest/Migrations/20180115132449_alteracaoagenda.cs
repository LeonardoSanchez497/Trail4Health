using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Trail4Healthtest.Migrations
{
    public partial class alteracaoagenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "estadoagendado",
                table: "AgendaTuristaTrilho",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgendaTuristaTrilho_EstadoTrilho_estadoagendado",
                table: "AgendaTuristaTrilho");

            migrationBuilder.DropIndex(
                name: "IX_AgendaTuristaTrilho_estadoagendado",
                table: "AgendaTuristaTrilho");

            migrationBuilder.AlterColumn<string>(
                name: "estadoagendado",
                table: "AgendaTuristaTrilho",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 150);
        }
    }
}
