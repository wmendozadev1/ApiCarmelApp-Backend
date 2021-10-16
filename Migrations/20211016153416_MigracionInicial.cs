using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APICarmel.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralContributions",
                columns: table => new
                {
                    IdContribution = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeptCordoba = table.Column<double>(type: "float", nullable: false),
                    SeptDolar = table.Column<double>(type: "float", nullable: false),
                    AnivCordoba = table.Column<double>(type: "float", nullable: false),
                    AnivDolar = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralContributions", x => x.IdContribution);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    IdMember = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEntry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDateReEntry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdVacancie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.IdMember);
                });

            migrationBuilder.CreateTable(
                name: "PersonalContributions",
                columns: table => new
                {
                    IdContribution = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMember = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProCasaCordoba = table.Column<double>(type: "float", nullable: false),
                    ProCasaDolar = table.Column<double>(type: "float", nullable: false),
                    ProMejoraCordoba = table.Column<double>(type: "float", nullable: false),
                    ProMejoraDolar = table.Column<double>(type: "float", nullable: false),
                    ProRentaCordoba = table.Column<double>(type: "float", nullable: false),
                    ProRentaDolar = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalContributions", x => x.IdContribution);
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    IdVacancie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.IdVacancie);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralContributions");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "PersonalContributions");

            migrationBuilder.DropTable(
                name: "Vacancies");
        }
    }
}
