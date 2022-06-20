using Microsoft.EntityFrameworkCore.Migrations;

namespace AgreementSystem.Migrations
{
    public partial class AddProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Group_Id = table.Column<int>(nullable: false),
                    Product_Description = table.Column<string>(nullable: true),
                    Product_Number = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_Product_Group_Id",
                        column: x => x.Product_Group_Id,
                        principalTable: "ProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Product_Group_Id",
                table: "Products",
                column: "Product_Group_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Product_Number",
                table: "Products",
                column: "Product_Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
