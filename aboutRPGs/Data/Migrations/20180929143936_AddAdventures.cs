using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aboutRPGs.Data.Migrations
{
    public partial class AddAdventures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adventures",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    title = table.Column<string>(nullable: false),
                    game = table.Column<string>(nullable: false),
                    meet = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Adventures");
        }
    }
}
