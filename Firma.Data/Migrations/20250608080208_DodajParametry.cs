using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    /// <inheritdoc />
    public partial class DodajParametry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jachty_KategorieJachtow_KategoriaJachtuIdKategorii",
                table: "Jachty");

            migrationBuilder.DropForeignKey(
                name: "FK_Jachty_Porty_PortIdPortu",
                table: "Jachty");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Jachty_JachtIdJachtu",
                table: "Rezerwacje");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Klienci_KlientIdKlienta",
                table: "Rezerwacje");

            migrationBuilder.DropForeignKey(
                name: "FK_ZdjeciaJachtow_Jachty_JachtIdJachtu",
                table: "ZdjeciaJachtow");

            migrationBuilder.DropIndex(
                name: "IX_ZdjeciaJachtow_JachtIdJachtu",
                table: "ZdjeciaJachtow");

            migrationBuilder.DropIndex(
                name: "IX_Rezerwacje_JachtIdJachtu",
                table: "Rezerwacje");

            migrationBuilder.DropIndex(
                name: "IX_Rezerwacje_KlientIdKlienta",
                table: "Rezerwacje");

            migrationBuilder.DropIndex(
                name: "IX_Jachty_KategoriaJachtuIdKategorii",
                table: "Jachty");

            migrationBuilder.DropIndex(
                name: "IX_Jachty_PortIdPortu",
                table: "Jachty");

            migrationBuilder.DropColumn(
                name: "JachtIdJachtu",
                table: "ZdjeciaJachtow");

            migrationBuilder.DropColumn(
                name: "JachtIdJachtu",
                table: "Rezerwacje");

            migrationBuilder.DropColumn(
                name: "KlientIdKlienta",
                table: "Rezerwacje");

            migrationBuilder.DropColumn(
                name: "KategoriaJachtuIdKategorii",
                table: "Jachty");

            migrationBuilder.DropColumn(
                name: "PortIdPortu",
                table: "Jachty");

            migrationBuilder.CreateTable(
                name: "Parametry",
                columns: table => new
                {
                    IdParametru = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Klucz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wartosc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametry", x => x.IdParametru);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZdjeciaJachtow_IdJachtu",
                table: "ZdjeciaJachtow",
                column: "IdJachtu");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_IdJachtu",
                table: "Rezerwacje",
                column: "IdJachtu");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_IdKlienta",
                table: "Rezerwacje",
                column: "IdKlienta");

            migrationBuilder.CreateIndex(
                name: "IX_Jachty_IdKategorii",
                table: "Jachty",
                column: "IdKategorii");

            migrationBuilder.CreateIndex(
                name: "IX_Jachty_IdPortu",
                table: "Jachty",
                column: "IdPortu");

            migrationBuilder.AddForeignKey(
                name: "FK_Jachty_KategorieJachtow_IdKategorii",
                table: "Jachty",
                column: "IdKategorii",
                principalTable: "KategorieJachtow",
                principalColumn: "IdKategorii",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jachty_Porty_IdPortu",
                table: "Jachty",
                column: "IdPortu",
                principalTable: "Porty",
                principalColumn: "IdPortu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Jachty_IdJachtu",
                table: "Rezerwacje",
                column: "IdJachtu",
                principalTable: "Jachty",
                principalColumn: "IdJachtu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Klienci_IdKlienta",
                table: "Rezerwacje",
                column: "IdKlienta",
                principalTable: "Klienci",
                principalColumn: "IdKlienta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZdjeciaJachtow_Jachty_IdJachtu",
                table: "ZdjeciaJachtow",
                column: "IdJachtu",
                principalTable: "Jachty",
                principalColumn: "IdJachtu",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jachty_KategorieJachtow_IdKategorii",
                table: "Jachty");

            migrationBuilder.DropForeignKey(
                name: "FK_Jachty_Porty_IdPortu",
                table: "Jachty");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Jachty_IdJachtu",
                table: "Rezerwacje");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Klienci_IdKlienta",
                table: "Rezerwacje");

            migrationBuilder.DropForeignKey(
                name: "FK_ZdjeciaJachtow_Jachty_IdJachtu",
                table: "ZdjeciaJachtow");

            migrationBuilder.DropTable(
                name: "Parametry");

            migrationBuilder.DropIndex(
                name: "IX_ZdjeciaJachtow_IdJachtu",
                table: "ZdjeciaJachtow");

            migrationBuilder.DropIndex(
                name: "IX_Rezerwacje_IdJachtu",
                table: "Rezerwacje");

            migrationBuilder.DropIndex(
                name: "IX_Rezerwacje_IdKlienta",
                table: "Rezerwacje");

            migrationBuilder.DropIndex(
                name: "IX_Jachty_IdKategorii",
                table: "Jachty");

            migrationBuilder.DropIndex(
                name: "IX_Jachty_IdPortu",
                table: "Jachty");

            migrationBuilder.AddColumn<int>(
                name: "JachtIdJachtu",
                table: "ZdjeciaJachtow",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JachtIdJachtu",
                table: "Rezerwacje",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KlientIdKlienta",
                table: "Rezerwacje",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KategoriaJachtuIdKategorii",
                table: "Jachty",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortIdPortu",
                table: "Jachty",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZdjeciaJachtow_JachtIdJachtu",
                table: "ZdjeciaJachtow",
                column: "JachtIdJachtu");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_JachtIdJachtu",
                table: "Rezerwacje",
                column: "JachtIdJachtu");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_KlientIdKlienta",
                table: "Rezerwacje",
                column: "KlientIdKlienta");

            migrationBuilder.CreateIndex(
                name: "IX_Jachty_KategoriaJachtuIdKategorii",
                table: "Jachty",
                column: "KategoriaJachtuIdKategorii");

            migrationBuilder.CreateIndex(
                name: "IX_Jachty_PortIdPortu",
                table: "Jachty",
                column: "PortIdPortu");

            migrationBuilder.AddForeignKey(
                name: "FK_Jachty_KategorieJachtow_KategoriaJachtuIdKategorii",
                table: "Jachty",
                column: "KategoriaJachtuIdKategorii",
                principalTable: "KategorieJachtow",
                principalColumn: "IdKategorii");

            migrationBuilder.AddForeignKey(
                name: "FK_Jachty_Porty_PortIdPortu",
                table: "Jachty",
                column: "PortIdPortu",
                principalTable: "Porty",
                principalColumn: "IdPortu");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Jachty_JachtIdJachtu",
                table: "Rezerwacje",
                column: "JachtIdJachtu",
                principalTable: "Jachty",
                principalColumn: "IdJachtu");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Klienci_KlientIdKlienta",
                table: "Rezerwacje",
                column: "KlientIdKlienta",
                principalTable: "Klienci",
                principalColumn: "IdKlienta");

            migrationBuilder.AddForeignKey(
                name: "FK_ZdjeciaJachtow_Jachty_JachtIdJachtu",
                table: "ZdjeciaJachtow",
                column: "JachtIdJachtu",
                principalTable: "Jachty",
                principalColumn: "IdJachtu");
        }
    }
}
