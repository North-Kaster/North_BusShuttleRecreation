using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusShuttleMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLoops_BusRoute_BusRouteId",
                table: "BusLoops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusRoute",
                table: "BusRoute");

            migrationBuilder.RenameTable(
                name: "BusRoute",
                newName: "BusRoutes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusRoutes",
                table: "BusRoutes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLoops_BusRoutes_BusRouteId",
                table: "BusLoops",
                column: "BusRouteId",
                principalTable: "BusRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLoops_BusRoutes_BusRouteId",
                table: "BusLoops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusRoutes",
                table: "BusRoutes");

            migrationBuilder.RenameTable(
                name: "BusRoutes",
                newName: "BusRoute");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusRoute",
                table: "BusRoute",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLoops_BusRoute_BusRouteId",
                table: "BusLoops",
                column: "BusRouteId",
                principalTable: "BusRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
