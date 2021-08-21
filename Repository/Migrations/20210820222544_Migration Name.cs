using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "id", "created_date", "status", "updated_date", "user" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jay krishna Reddy" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "id", "created_date", "status", "updated_date", "user" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inactivo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sey Karl Chan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
