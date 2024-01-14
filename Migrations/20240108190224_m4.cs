using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalaApp.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbonamentClient");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Abonament",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Abonament_ClientID",
                table: "Abonament",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Abonament_Client_ClientID",
                table: "Abonament",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abonament_Client_ClientID",
                table: "Abonament");

            migrationBuilder.DropIndex(
                name: "IX_Abonament_ClientID",
                table: "Abonament");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Abonament");

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
                name: "IX_AbonamentClient_ClientiID",
                table: "AbonamentClient",
                column: "ClientiID");
        }
    }
}
