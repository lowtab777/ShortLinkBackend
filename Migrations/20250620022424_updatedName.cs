using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShortLinkBackend.Migrations
{
    /// <inheritdoc />
    public partial class updatedName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDat",
                table: "ShortLinks",
                newName: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "ShortLinks",
                newName: "CreatedDat");
        }
    }
}
