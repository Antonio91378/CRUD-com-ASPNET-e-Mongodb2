using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Blog.BackEnd.Migrations
{
    public partial class att2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    IdComment = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriationData = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.IdComment);
                });

            migrationBuilder.CreateTable(
                name: "RepliedComments",
                columns: table => new
                {
                    IdRepliedComment = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdComment = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriationData = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepliedComments", x => x.IdRepliedComment);
                    table.ForeignKey(
                        name: "FK_RepliedComments_Comments_IdComment",
                        column: x => x.IdComment,
                        principalTable: "Comments",
                        principalColumn: "IdComment",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepliedComments_IdComment",
                table: "RepliedComments",
                column: "IdComment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepliedComments");

            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
