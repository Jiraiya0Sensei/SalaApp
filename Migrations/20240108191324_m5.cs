using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalaApp.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SportID",
                table: "Abonament",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Abonament_SportID",
                table: "Abonament",
                column: "SportID");

            migrationBuilder.AddForeignKey(
                name: "FK_Abonament_Sport_SportID",
                table: "Abonament",
                column: "SportID",
                principalTable: "Sport",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abonament_Sport_SportID",
                table: "Abonament");

            migrationBuilder.DropIndex(
                name: "IX_Abonament_SportID",
                table: "Abonament");

            migrationBuilder.DropColumn(
                name: "SportID",
                table: "Abonament");
        }
    }
}
