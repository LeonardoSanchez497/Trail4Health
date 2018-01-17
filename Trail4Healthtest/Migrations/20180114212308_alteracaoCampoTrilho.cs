using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Trail4Healthtest.Migrations
{
    public partial class alteracaoCampoTrilho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ativo",
                table: "Trilho",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ativo",
                table: "Trilho",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
