using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IPInfos",
                columns: table => new
                {
                    StartIP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EndIP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IntermediateIP = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPInfos", x => new { x.StartIP, x.EndIP });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPInfos");
        }
    }
}
