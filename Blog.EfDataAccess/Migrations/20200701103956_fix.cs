using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.EfDataAccess.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "alt",
                table: "Pictures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "alt",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
