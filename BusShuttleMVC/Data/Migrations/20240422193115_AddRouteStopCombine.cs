using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusShuttleMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRouteStopCombine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusStops_BusRoutes_RouteId",
                table: "BusStops");

            migrationBuilder.DropIndex(
                name: "IX_BusStops_RouteId",
                table: "BusStops");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "BusStops");

            migrationBuilder.CreateTable(
                name: "RouteStop",
                columns: table => new
                {
                    BusRouteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BusStopId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteStop", x => new { x.BusRouteId, x.BusStopId });
                    table.ForeignKey(
                        name: "FK_RouteStop_BusRoutes_BusRouteId",
                        column: x => x.BusRouteId,
                        principalTable: "BusRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteStop_BusStops_BusStopId",
                        column: x => x.BusStopId,
                        principalTable: "BusStops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RouteStop_BusStopId",
                table: "RouteStop",
                column: "BusStopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RouteStop");

            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "BusStops",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusStops_RouteId",
                table: "BusStops",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusStops_BusRoutes_RouteId",
                table: "BusStops",
                column: "RouteId",
                principalTable: "BusRoutes",
                principalColumn: "Id");
        }
    }
}
