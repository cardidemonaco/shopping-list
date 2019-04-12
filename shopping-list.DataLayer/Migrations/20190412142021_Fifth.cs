using Microsoft.EntityFrameworkCore.Migrations;

namespace shopping_list.DataLayer.Migrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BrandName",
                table: "Brand",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BrandName",
                table: "Brand",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
