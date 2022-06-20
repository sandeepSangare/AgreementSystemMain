using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgreementSystem.Migrations
{
    public partial class AddAgreement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(nullable: false),
                    Product_Group_Id = table.Column<int>(nullable: false),
                    Product_Id = table.Column<int>(nullable: false),
                    Effective_Date = table.Column<DateTime>(nullable: false),
                    Expiration_Date = table.Column<DateTime>(nullable: false),
                    Product_Price = table.Column<double>(nullable: false),
                    New_Price = table.Column<double>(nullable: false),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Agreements_ProductGroups_Product_Group_Id",
                        column: x => x.Product_Group_Id,
                        principalTable: "ProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Agreements_Products_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_Product_Group_Id",
                table: "Agreements",
                column: "Product_Group_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_Product_Id",
                table: "Agreements",
                column: "Product_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreements");
        }
    }
}
