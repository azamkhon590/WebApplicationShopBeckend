using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationBackend.Migrations
{
    public partial class UserCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    password = table.Column<int>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(319)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
