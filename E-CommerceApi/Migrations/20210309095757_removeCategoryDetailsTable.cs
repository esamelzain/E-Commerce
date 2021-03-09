using Microsoft.EntityFrameworkCore.Migrations;

namespace E_CommerceApi.Migrations
{
    public partial class removeCategoryDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryDescription",
                table: "CategoryMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryIcon",
                table: "CategoryMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryImage",
                table: "CategoryMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryLink",
                table: "CategoryMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryMenuImage",
                table: "CategoryMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "CategoryMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "CategoryMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaKeywords",
                table: "CategoryMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "CategoryMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadMoreLink",
                table: "CategoryMain",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryDescription",
                table: "CategoryMain");

            migrationBuilder.DropColumn(
                name: "CategoryIcon",
                table: "CategoryMain");

            migrationBuilder.DropColumn(
                name: "CategoryImage",
                table: "CategoryMain");

            migrationBuilder.DropColumn(
                name: "CategoryLink",
                table: "CategoryMain");

            migrationBuilder.DropColumn(
                name: "CategoryMenuImage",
                table: "CategoryMain");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "CategoryMain");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "CategoryMain");

            migrationBuilder.DropColumn(
                name: "MetaKeywords",
                table: "CategoryMain");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "CategoryMain");

            migrationBuilder.DropColumn(
                name: "ReadMoreLink",
                table: "CategoryMain");
        }
    }
}
