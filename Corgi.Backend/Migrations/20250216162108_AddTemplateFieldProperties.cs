using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corgi.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddTemplateFieldProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FieldType",
                table: "TemplateFields",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "TemplateFields",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "TemplateFields",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldType",
                table: "TemplateFields");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "TemplateFields");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "TemplateFields");
        }
    }
}
