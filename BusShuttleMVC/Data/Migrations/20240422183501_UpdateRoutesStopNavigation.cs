using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusShuttleMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoutesStopNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusStops_BusRoutes_BusRouteId",
                table: "BusStops");

            migrationBuilder.AlterColumn<Guid>(
                name: "BusRouteId",
                table: "BusStops",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BusStops_BusRoutes_BusRouteId",
                table: "BusStops",
                column: "BusRouteId",
                principalTable: "BusRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusStops_BusRoutes_BusRouteId",
                table: "BusStops");

            migrationBuilder.AlterColumn<Guid>(
                name: "BusRouteId",
                table: "BusStops",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_BusStops_BusRoutes_BusRouteId",
                table: "BusStops",
                column: "BusRouteId",
                principalTable: "BusRoutes",
                principalColumn: "Id");
        }
    }
}
