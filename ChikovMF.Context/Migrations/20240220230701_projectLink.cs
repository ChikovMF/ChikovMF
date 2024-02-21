﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChikovMF.Context.Migrations
{
    /// <inheritdoc />
    public partial class projectLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectLinks",
                columns: table => new
                {
                    ProjectLinkId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectLinks", x => x.ProjectLinkId);
                    table.ForeignKey(
                        name: "FK_ProjectLinks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLinks_ProjectId",
                table: "ProjectLinks",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectLinks");
        }
    }
}
