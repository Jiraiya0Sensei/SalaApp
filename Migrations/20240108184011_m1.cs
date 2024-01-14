using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalaApp.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Abonament_AbonamentID",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_AbonamentID",
                table: "Client");

            migrationBuilder.AlterColumn<string>(
                name: "AbonamentID",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AbonamentClient",
                columns: table => new
                {
                    AbonamenteID = table.Column<int>(type: "int", nullable: false),
                    ClientiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonamentClient", x => new { x.AbonamenteID, x.ClientiID });
                    table.ForeignKey(
                        name: "FK_AbonamentClient_Abonament_AbonamenteID",
                        column: x => x.AbonamenteID,
                        principalTable: "Abonament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbonamentClient_Client_ClientiID",
                        column: x => x.ClientiID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Antrenor_SportID",
                table: "Antrenor",
                column: "SportID");

            migrationBuilder.CreateIndex(
                name: "IX_AbonamentClient_ClientiID",
                table: "AbonamentClient",
                column: "ClientiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Antrenor_Sport_SportID",
                table: "Antrenor",
                column: "SportID",
                principalTable: "Sport",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Antrenor_Sport_SportID",
                table: "Antrenor");

            migrationBuilder.DropTable(
                name: "AbonamentClient");

            migrationBuilder.DropIndex(
                name: "IX_Antrenor_SportID",
                table: "Antrenor");

            migrationBuilder.AlterColumn<int>(
                name: "AbonamentID",
                table: "Client",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Client_AbonamentID",
                table: "Client",
                column: "AbonamentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Abonament_AbonamentID",
                table: "Client",
                column: "AbonamentID",
                principalTable: "Abonament",
                principalColumn: "ID");
        }
    }
}
