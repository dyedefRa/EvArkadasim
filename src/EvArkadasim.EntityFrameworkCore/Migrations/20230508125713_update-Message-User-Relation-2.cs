using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvArkadasim.Migrations
{
    public partial class updateMessageUserRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppMessages_AbpUsers_ReceiverId",
                table: "AppMessages");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReceiverId",
                table: "AppMessages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppMessages_AbpUsers_ReceiverId",
                table: "AppMessages",
                column: "ReceiverId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppMessages_AbpUsers_ReceiverId",
                table: "AppMessages");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReceiverId",
                table: "AppMessages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_AppMessages_AbpUsers_ReceiverId",
                table: "AppMessages",
                column: "ReceiverId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
