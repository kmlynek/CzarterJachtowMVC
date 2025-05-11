using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    /// <inheritdoc />
    public partial class BazaJachty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KategorieJachtow",
                columns: table => new
                {
                    IdKategorii = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorieJachtow", x => x.IdKategorii);
                });

            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    IdKlienta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.IdKlienta);
                });

            migrationBuilder.CreateTable(
                name: "Porty",
                columns: table => new
                {
                    IdPortu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lokalizacja = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porty", x => x.IdPortu);
                });

            migrationBuilder.CreateTable(
                name: "Zapytania",
                columns: table => new
                {
                    IdZapytania = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataWyslania = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zapytania", x => x.IdZapytania);
                });

            migrationBuilder.CreateTable(
                name: "Jachty",
                columns: table => new
                {
                    IdJachtu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RokBudowy = table.Column<int>(type: "int", nullable: false),
                    CenaZaDzien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdKategorii = table.Column<int>(type: "int", nullable: false),
                    KategoriaJachtuIdKategorii = table.Column<int>(type: "int", nullable: true),
                    IdPortu = table.Column<int>(type: "int", nullable: false),
                    PortIdPortu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jachty", x => x.IdJachtu);
                    table.ForeignKey(
                        name: "FK_Jachty_KategorieJachtow_KategoriaJachtuIdKategorii",
                        column: x => x.KategoriaJachtuIdKategorii,
                        principalTable: "KategorieJachtow",
                        principalColumn: "IdKategorii");
                    table.ForeignKey(
                        name: "FK_Jachty_Porty_PortIdPortu",
                        column: x => x.PortIdPortu,
                        principalTable: "Porty",
                        principalColumn: "IdPortu");
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacje",
                columns: table => new
                {
                    IdRezerwacji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdJachtu = table.Column<int>(type: "int", nullable: false),
                    JachtIdJachtu = table.Column<int>(type: "int", nullable: true),
                    IdKlienta = table.Column<int>(type: "int", nullable: false),
                    KlientIdKlienta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacje", x => x.IdRezerwacji);
                    table.ForeignKey(
                        name: "FK_Rezerwacje_Jachty_JachtIdJachtu",
                        column: x => x.JachtIdJachtu,
                        principalTable: "Jachty",
                        principalColumn: "IdJachtu");
                    table.ForeignKey(
                        name: "FK_Rezerwacje_Klienci_KlientIdKlienta",
                        column: x => x.KlientIdKlienta,
                        principalTable: "Klienci",
                        principalColumn: "IdKlienta");
                });

            migrationBuilder.CreateTable(
                name: "ZdjeciaJachtow",
                columns: table => new
                {
                    IdZdjecia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sciezka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdJachtu = table.Column<int>(type: "int", nullable: false),
                    JachtIdJachtu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdjeciaJachtow", x => x.IdZdjecia);
                    table.ForeignKey(
                        name: "FK_ZdjeciaJachtow_Jachty_JachtIdJachtu",
                        column: x => x.JachtIdJachtu,
                        principalTable: "Jachty",
                        principalColumn: "IdJachtu");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jachty_KategoriaJachtuIdKategorii",
                table: "Jachty",
                column: "KategoriaJachtuIdKategorii");

            migrationBuilder.CreateIndex(
                name: "IX_Jachty_PortIdPortu",
                table: "Jachty",
                column: "PortIdPortu");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_JachtIdJachtu",
                table: "Rezerwacje",
                column: "JachtIdJachtu");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_KlientIdKlienta",
                table: "Rezerwacje",
                column: "KlientIdKlienta");

            migrationBuilder.CreateIndex(
                name: "IX_ZdjeciaJachtow_JachtIdJachtu",
                table: "ZdjeciaJachtow",
                column: "JachtIdJachtu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezerwacje");

            migrationBuilder.DropTable(
                name: "Zapytania");

            migrationBuilder.DropTable(
                name: "ZdjeciaJachtow");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Jachty");

            migrationBuilder.DropTable(
                name: "KategorieJachtow");

            migrationBuilder.DropTable(
                name: "Porty");
        }
    }
}
