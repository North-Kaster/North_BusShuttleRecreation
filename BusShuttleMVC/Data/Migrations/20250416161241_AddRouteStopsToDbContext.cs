using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusShuttleMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRouteStopsToDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteStop_BusRoutes_BusRouteId",
                table: "RouteStop");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteStop_BusStops_BusStopId",
                table: "RouteStop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RouteStop",
                table: "RouteStop");

            migrationBuilder.RenameTable(
                name: "RouteStop",
                newName: "RouteStops");

            migrationBuilder.RenameIndex(
                name: "IX_RouteStop_BusStopId",
                table: "RouteStops",
                newName: "IX_RouteStops_BusStopId");

            migrationBuilder.RenameIndex(
                name: "IX_RouteStop_BusRouteId",
                table: "RouteStops",
                newName: "IX_RouteStops_BusRouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RouteStops",
                table: "RouteStops",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStops_BusRoutes_BusRouteId",
                table: "RouteStops",
                column: "BusRouteId",
                principalTable: "BusRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStops_BusStops_BusStopId",
                table: "RouteStops",
                column: "BusStopId",
                principalTable: "BusStops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteStops_BusRoutes_BusRouteId",
                table: "RouteStops");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteStops_BusStops_BusStopId",
                table: "RouteStops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RouteStops",
                table: "RouteStops");

            migrationBuilder.RenameTable(
                name: "RouteStops",
                newName: "RouteStop");

            migrationBuilder.RenameIndex(
                name: "IX_RouteStops_BusStopId",
                table: "RouteStop",
                newName: "IX_RouteStop_BusStopId");

            migrationBuilder.RenameIndex(
                name: "IX_RouteStops_BusRouteId",
                table: "RouteStop",
                newName: "IX_RouteStop_BusRouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RouteStop",
                table: "RouteStop",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStop_BusRoutes_BusRouteId",
                table: "RouteStop",
                column: "BusRouteId",
                principalTable: "BusRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStop_BusStops_BusStopId",
                table: "RouteStop",
                column: "BusStopId",
                principalTable: "BusStops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
