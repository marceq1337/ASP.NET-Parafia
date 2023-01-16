using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace parafia2.Migrations
{
    /// <inheritdoc />
    public partial class cos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ministranci",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Nazwisko = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Dataurodzenia = table.Column<DateTime>(name: "Data_urodzenia", type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ministranci", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Stanowiska",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwastanowiska = table.Column<string>(name: "Nazwa_stanowiska", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanowiska", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ksieza",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Nazwisko = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Stanowisko = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksieza", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ksieza_Stanowiska",
                        column: x => x.Stanowisko,
                        principalTable: "Stanowiska",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Msze",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datamszy = table.Column<DateTime>(name: "Data_mszy", type: "date", nullable: true),
                    ksiadz = table.Column<int>(type: "int", nullable: true),
                    ministrant = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Msze", x => x.id);
                    table.ForeignKey(
                        name: "FK_Msze_Ksieza",
                        column: x => x.ksiadz,
                        principalTable: "Ksieza",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Msze_Ministranci",
                        column: x => x.ministrant,
                        principalTable: "Ministranci",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ksieza_Stanowisko",
                table: "Ksieza",
                column: "Stanowisko");

            migrationBuilder.CreateIndex(
                name: "IX_Msze_ksiadz",
                table: "Msze",
                column: "ksiadz");

            migrationBuilder.CreateIndex(
                name: "IX_Msze_ministrant",
                table: "Msze",
                column: "ministrant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Msze");

            migrationBuilder.DropTable(
                name: "Ksieza");

            migrationBuilder.DropTable(
                name: "Ministranci");

            migrationBuilder.DropTable(
                name: "Stanowiska");
        }
    }
}
