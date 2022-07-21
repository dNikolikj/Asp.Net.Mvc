using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerApp.DataAccess_Refactored.Migrations
{
    public partial class test123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Burgers_BurgerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BurgerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BurgerId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BurgerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "BurgerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "BurgerId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "BurgerId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BurgerId",
                table: "Orders",
                column: "BurgerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Burgers_BurgerId",
                table: "Orders",
                column: "BurgerId",
                principalTable: "Burgers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
