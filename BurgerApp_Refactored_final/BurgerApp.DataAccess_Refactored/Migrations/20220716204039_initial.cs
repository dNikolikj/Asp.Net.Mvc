using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerApp.DataAccess_Refactored.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burgers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    TypeOfBurger = table.Column<int>(type: "int", nullable: false),
                    HasFries = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burgers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurgerId = table.Column<int>(type: "int", nullable: false),
                    StoreAddress = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Burgers_BurgerId",
                        column: x => x.BurgerId,
                        principalTable: "Burgers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BurgerBasket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BurgerId = table.Column<int>(type: "int", nullable: false),
                    NumberOfBurgers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurgerBasket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BurgerBasket_Burgers_BurgerId",
                        column: x => x.BurgerId,
                        principalTable: "Burgers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BurgerBasket_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Burgers",
                columns: new[] { "Id", "HasFries", "Name", "Price", "TypeOfBurger" },
                values: new object[,]
                {
                    { 1, true, "Veggie", 450.0, 3 },
                    { 2, true, "Black Angus", 500.0, 1 },
                    { 3, false, "The beyond Burger", 450.0, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "09692, Canicosa De La Sierra", "Ricky", "Rubio" },
                    { 2, "Long Branch, Cedar Avenue 331, New Jersey", "John", "Krasinski" },
                    { 3, "47 W 13th St, New York, NY 10011", "Paul", "Ekman" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BurgerId", "IsDelivered", "PaymentMethod", "StoreAddress", "UserId" },
                values: new object[] { 1, 1, true, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BurgerId", "IsDelivered", "PaymentMethod", "StoreAddress", "UserId" },
                values: new object[] { 2, 3, false, 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BurgerId", "IsDelivered", "PaymentMethod", "StoreAddress", "UserId" },
                values: new object[] { 3, 2, false, 2, 3, 3 });

            migrationBuilder.InsertData(
                table: "BurgerBasket",
                columns: new[] { "Id", "BurgerId", "NumberOfBurgers", "OrderId" },
                values: new object[] { 1, 2, 2, 1 });

            migrationBuilder.InsertData(
                table: "BurgerBasket",
                columns: new[] { "Id", "BurgerId", "NumberOfBurgers", "OrderId" },
                values: new object[] { 2, 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "BurgerBasket",
                columns: new[] { "Id", "BurgerId", "NumberOfBurgers", "OrderId" },
                values: new object[] { 3, 3, 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_BurgerBasket_BurgerId",
                table: "BurgerBasket",
                column: "BurgerId");

            migrationBuilder.CreateIndex(
                name: "IX_BurgerBasket_OrderId",
                table: "BurgerBasket",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BurgerId",
                table: "Orders",
                column: "BurgerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BurgerBasket");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Burgers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
