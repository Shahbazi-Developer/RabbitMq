using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book.Infra.Data.Sql.Commands.Migrations
{
    /// <inheritdoc />
    public partial class Editnameprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "BookShop",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "BookShop");
        }
    }
}
