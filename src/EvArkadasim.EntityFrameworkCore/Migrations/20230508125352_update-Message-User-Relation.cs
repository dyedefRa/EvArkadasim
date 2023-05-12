using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvArkadasim.Migrations
{
    public partial class updateMessageUserRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AppMessages");

            migrationBuilder.DropColumn(
                name: "FirstReceivedById",
                table: "AppMessages");

            migrationBuilder.AddColumn<Guid>(
                name: "ReceiverId",
                table: "AppMessages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SenderId",
                table: "AppMessages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppMessages_ReceiverId",
                table: "AppMessages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMessages_SenderId",
                table: "AppMessages",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppMessages_AbpUsers_ReceiverId",
                table: "AppMessages",
                column: "ReceiverId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppMessages_AbpUsers_SenderId",
                table: "AppMessages",
                column: "SenderId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppMessages_AbpUsers_ReceiverId",
                table: "AppMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_AppMessages_AbpUsers_SenderId",
                table: "AppMessages");

            migrationBuilder.DropIndex(
                name: "IX_AppMessages_ReceiverId",
                table: "AppMessages");

            migrationBuilder.DropIndex(
                name: "IX_AppMessages_SenderId",
                table: "AppMessages");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "AppMessages");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "AppMessages");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "AppMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirstReceivedById",
                table: "AppMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
