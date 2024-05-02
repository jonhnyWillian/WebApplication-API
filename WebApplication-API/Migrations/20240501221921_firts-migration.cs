using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_API.Migrations
{
    /// <inheritdoc />
    public partial class firtsmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    idPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nmPessoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtNasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nrCpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<int>(type: "int", nullable: false),
                    dtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtUltAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.idPessoa);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
