using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Blog.BackEnd.Migrations
{
    public partial class testeeeeeerere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageContent",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageContent",
                table: "Comments");
        }
    }
}
