using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    public partial class ChangeAtualizacaoRelacionamentoClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataFimRelacionamento",
                table: "AtualizacoesRelacionamentosClientes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicioRelacionamento",
                table: "AtualizacoesRelacionamentosClientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFimRelacionamento",
                table: "AtualizacoesRelacionamentosClientes");

            migrationBuilder.DropColumn(
                name: "DataInicioRelacionamento",
                table: "AtualizacoesRelacionamentosClientes");
        }
    }
}
