using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNX.Migrations
{
    public partial class AdicionadoPassworRequestRequestedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedOn",
                table: "PasswordResets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedOn",
                table: "PasswordResets");
        }
    }
}
