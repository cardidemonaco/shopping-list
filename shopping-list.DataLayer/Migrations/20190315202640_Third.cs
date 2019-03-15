using Microsoft.EntityFrameworkCore.Migrations;

namespace shopping_list.DataLayer.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "BrandId", "BrandName" },
                values: new object[,]
                {
                    { 1, "Faygo" },
                    { 2, "Coca Cola" },
                    { 3, "Pepsi" },
                    { 4, "Kleenex" },
                    { 5, "Charmin" }
                });

            migrationBuilder.InsertData(
                table: "ItemBrand",
                columns: new[] { "ItemId", "BrandId" },
                values: new object[] { 5, 1 });

            migrationBuilder.InsertData(
                table: "ItemBrand",
                columns: new[] { "ItemId", "BrandId" },
                values: new object[] { 5, 2 });

            migrationBuilder.InsertData(
                table: "ItemBrand",
                columns: new[] { "ItemId", "BrandId" },
                values: new object[] { 2, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "BrandId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "BrandId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ItemBrand",
                keyColumns: new[] { "ItemId", "BrandId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ItemBrand",
                keyColumns: new[] { "ItemId", "BrandId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ItemBrand",
                keyColumns: new[] { "ItemId", "BrandId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "BrandId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "BrandId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "BrandId",
                keyValue: 4);
        }
    }
}
