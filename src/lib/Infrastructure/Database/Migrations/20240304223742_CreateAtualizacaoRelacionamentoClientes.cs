using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    public partial class CreateAtualizacaoRelacionamentoClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtualizacoesRelacionamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeOperacao = table.Column<int>(type: "int", nullable: false),
                    NumeroRemessa = table.Column<int>(type: "int", nullable: false),
                    DataMovimentacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtualizacoesRelacionamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AtualizacoesRelacionamentosClientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoOperacao = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    QualificadorOperacao = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    AtualizacaoRelacionamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtualizacoesRelacionamentosClientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtualizacoesRelacionamentosClientes_AtualizacoesRelacionamentos_AtualizacaoRelacionamentoId",
                        column: x => x.AtualizacaoRelacionamentoId,
                        principalTable: "AtualizacoesRelacionamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtualizacoesRelacionamentosClientes_AtualizacaoRelacionamentoId",
                table: "AtualizacoesRelacionamentosClientes",
                column: "AtualizacaoRelacionamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtualizacoesRelacionamentosClientes");

            migrationBuilder.DropTable(
                name: "AtualizacoesRelacionamentos");
        }
    }
}
