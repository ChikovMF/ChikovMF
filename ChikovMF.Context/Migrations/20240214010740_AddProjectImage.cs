using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChikovMF.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectImage",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageType = table.Column<int>(type: "integer", nullable: false),
                    Src = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Alt = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProjectId1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectImage", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_ProjectImage_Projects_ProjectId1",
                        column: x => x.ProjectId1,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImage_ProjectId1",
                table: "ProjectImage",
                column: "ProjectId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectImage");
        }
    }
}
