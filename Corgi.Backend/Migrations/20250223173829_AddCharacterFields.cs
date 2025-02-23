using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corgi.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddCharacterFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Characters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TemplateId",
                table: "Characters",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CharacterFields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FieldType = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false),
                    OriginId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterFields_TemplateFields_OriginId",
                        column: x => x.OriginId,
                        principalTable: "TemplateFields",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_TemplateId",
                table: "Characters",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFields_OriginId",
                table: "CharacterFields",
                column: "OriginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Templates_TemplateId",
                table: "Characters",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Templates_TemplateId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "CharacterFields");

            migrationBuilder.DropIndex(
                name: "IX_Characters_TemplateId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "Characters");
        }
    }
}
