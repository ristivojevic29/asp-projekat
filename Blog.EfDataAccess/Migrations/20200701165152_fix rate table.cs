using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.EfDataAccess.Migrations
{
    public partial class fixratetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticalId",
                table: "Rates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticalId",
                table: "Rates",
                type: "int",
                nullable: true);
        }
    }
}
