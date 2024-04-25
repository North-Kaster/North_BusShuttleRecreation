using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusShuttleMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AllowMultipleIdenticalStopsOnRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RouteStop",
                table: "RouteStop");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "RouteStop",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RouteStop",
                table: "RouteStop",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RouteStop_BusRouteId",
                table: "RouteStop",
                column: "BusRouteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RouteStop",
                table: "RouteStop");

            migrationBuilder.DropIndex(
                name: "IX_RouteStop_BusRouteId",
                table: "RouteStop");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RouteStop");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RouteStop",
                table: "RouteStop",
                columns: new[] { "BusRouteId", "BusStopId" });
        }
    }
}
