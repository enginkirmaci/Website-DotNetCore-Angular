using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Website.Core.Models.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Pages_PageId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_PageId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "PageId",
                table: "Files");

            migrationBuilder.AddColumn<long>(
                name: "RelatedId",
                table: "Files",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelatedId",
                table: "Files");

            migrationBuilder.AddColumn<long>(
                name: "PageId",
                table: "Files",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_PageId",
                table: "Files",
                column: "PageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Pages_PageId",
                table: "Files",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
