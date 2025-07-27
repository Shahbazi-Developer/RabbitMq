using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book.Infra.Data.Sql.Commands.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "zamin");

            migrationBuilder.CreateTable(
                name: "BookShops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Language = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PublicationYear = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    Edition = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: true),
                    StockQuantity = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookShops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutBoxEventItems",
                schema: "zamin",
                columns: table => new
                {
                    OutBoxEventItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccuredByUserId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AccuredOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AggregateName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AggregateTypeName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AggregateId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EventTypeName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EventPayload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraceId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SpanId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsProcessed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutBoxEventItems", x => x.OutBoxEventItemId);
                });

            migrationBuilder.CreateTable(
                name: "BookShopCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryTitle = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Authors = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BookShopId = table.Column<int>(type: "int", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookShopCategorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookShopCategorys_BookShops_BookShopId",
                        column: x => x.BookShopId,
                        principalTable: "BookShops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookShopCategorys_BookShopId",
                table: "BookShopCategorys",
                column: "BookShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookShopCategorys");

            migrationBuilder.DropTable(
                name: "OutBoxEventItems",
                schema: "zamin");

            migrationBuilder.DropTable(
                name: "BookShops");
        }
    }
}
