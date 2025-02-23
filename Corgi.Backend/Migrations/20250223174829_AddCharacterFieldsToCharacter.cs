using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corgi.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddCharacterFieldsToCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CharacterId",
                table: "CharacterFields",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFields_CharacterId",
                table: "CharacterFields",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterFields_Characters_CharacterId",
                table: "CharacterFields",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFields_Characters_CharacterId",
                table: "CharacterFields");

            migrationBuilder.DropIndex(
                name: "IX_CharacterFields_CharacterId",
                table: "CharacterFields");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "CharacterFields");
        }
    }
}
