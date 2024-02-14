using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChikovMF.Context.Migrations
{
    /// <inheritdoc />
    public partial class FixIdProjectImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectImage_Projects_ProjectId1",
                table: "ProjectImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectImage",
                table: "ProjectImage");

            migrationBuilder.DropIndex(
                name: "IX_ProjectImage_ProjectId1",
                table: "ProjectImage");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "ProjectImage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectImage",
                table: "ProjectImage",
                column: "ProjectImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImage_ProjectId",
                table: "ProjectImage",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectImage_Projects_ProjectId",
                table: "ProjectImage",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectImage_Projects_ProjectId",
                table: "ProjectImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectImage",
                table: "ProjectImage");

            migrationBuilder.DropIndex(
                name: "IX_ProjectImage_ProjectId",
                table: "ProjectImage");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId1",
                table: "ProjectImage",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectImage",
                table: "ProjectImage",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImage_ProjectId1",
                table: "ProjectImage",
                column: "ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectImage_Projects_ProjectId1",
                table: "ProjectImage",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
