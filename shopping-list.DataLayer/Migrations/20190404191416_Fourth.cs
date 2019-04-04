using Microsoft.EntityFrameworkCore.Migrations;

namespace shopping_list.DataLayer.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemDescription",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrandNotes",
                table: "Brand",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrandWebsite",
                table: "Brand",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemDescription",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BrandNotes",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "BrandWebsite",
                table: "Brand");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
