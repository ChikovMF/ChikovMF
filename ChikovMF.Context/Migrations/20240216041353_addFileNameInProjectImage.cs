using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChikovMF.Context.Migrations
{
    /// <inheritdoc />
    public partial class addFileNameInProjectImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "ProjectImage",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "ProjectImage");
        }
    }
}
