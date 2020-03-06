using Microsoft.EntityFrameworkCore.Migrations;

namespace BookManagements.Migrations
{
    public partial class ConvertingbacktoInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Review",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Review",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
