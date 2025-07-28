using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book.Infra.Data.Sql.Commands.Migrations
{
    /// <inheritdoc />
    public partial class AddDeleteBookShopCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookShopCategorys_BookShops_BookShopId",
                table: "BookShopCategorys");

            migrationBuilder.AlterColumn<int>(
                name: "BookShopId",
                table: "BookShopCategorys",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "BookShopCategorys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_BookShopCategorys_BookShops_BookShopId",
                table: "BookShopCategorys",
                column: "BookShopId",
                principalTable: "BookShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookShopCategorys_BookShops_BookShopId",
                table: "BookShopCategorys");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "BookShopCategorys");

            migrationBuilder.AlterColumn<int>(
                name: "BookShopId",
                table: "BookShopCategorys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BookShopCategorys_BookShops_BookShopId",
                table: "BookShopCategorys",
                column: "BookShopId",
                principalTable: "BookShops",
                principalColumn: "Id");
        }
    }
}
