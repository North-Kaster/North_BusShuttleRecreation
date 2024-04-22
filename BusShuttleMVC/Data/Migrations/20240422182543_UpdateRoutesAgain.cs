using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusShuttleMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoutesAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StopIds",
                table: "BusRoutes");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "StopIds",
                table: "BusRoutes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
