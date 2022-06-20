using Microsoft.EntityFrameworkCore.Migrations;

namespace AgreementSystem.Migrations
{
    public partial class UpdateAgreementActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Agreements",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Active",
                table: "Agreements",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
