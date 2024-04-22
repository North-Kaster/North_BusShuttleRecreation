using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusShuttleMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class addBaseModelBuilder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusStops_BusRoutes_BusRouteId",
                table: "BusStops");

            migrationBuilder.DropIndex(
                name: "IX_BusStops_BusRouteId",
                table: "BusStops");

            migrationBuilder.DropColumn(
                name: "BusRouteId",
                table: "BusStops");

            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "BusStops",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BusStops_RouteId",
                table: "BusStops",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusStops_BusRoutes_RouteId",
                table: "BusStops",
                column: "RouteId",
                principalTable: "BusRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "BusRouteId",
                table: "BusStops",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusStops_BusRouteId",
                table: "BusStops",
                column: "BusRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusStops_BusRoutes_BusRouteId",
                table: "BusStops",
                column: "BusRouteId",
                principalTable: "BusRoutes",
                principalColumn: "Id");
        }
    }
}
