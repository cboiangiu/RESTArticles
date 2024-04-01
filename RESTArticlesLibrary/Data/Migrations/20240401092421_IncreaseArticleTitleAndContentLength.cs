using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTArticlesLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class IncreaseArticleTitleAndContentLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Articles",
                type: "varchar(20000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10000)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(60)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Articles",
                type: "varchar(10000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20000)");
        }
    }
}
