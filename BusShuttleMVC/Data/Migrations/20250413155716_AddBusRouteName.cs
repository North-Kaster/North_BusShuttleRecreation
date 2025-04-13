using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusShuttleMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBusRouteName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BusRoutes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "BusRoutes");
        }
    }
}
