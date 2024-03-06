using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    COD_STUDENT = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDENTIFICATION = table.Column<string>(maxLength: 20, nullable: false),
                    GENDER = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(maxLength: 50, nullable: false),
                    LASTNAME = table.Column<string>(maxLength: 50, nullable: false),
                    COURSE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.COD_STUDENT);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student");
        }
    }
}
