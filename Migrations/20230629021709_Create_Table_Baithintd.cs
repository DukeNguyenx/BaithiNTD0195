using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaithiNTD0195.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_Baithintd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baithintd",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    Number = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baithintd", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baithintd");
        }
    }
}
