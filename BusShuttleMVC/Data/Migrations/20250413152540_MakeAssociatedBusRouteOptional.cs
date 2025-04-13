using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusShuttleMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeAssociatedBusRouteOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLoops_BusRoutes_BusRouteId",
                table: "BusLoops");

            migrationBuilder.AlterColumn<Guid>(
                name: "BusRouteId",
                table: "BusLoops",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLoops_BusRoutes_BusRouteId",
                table: "BusLoops",
                column: "BusRouteId",
                principalTable: "BusRoutes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLoops_BusRoutes_BusRouteId",
                table: "BusLoops");

            migrationBuilder.AlterColumn<Guid>(
                name: "BusRouteId",
                table: "BusLoops",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BusLoops_BusRoutes_BusRouteId",
                table: "BusLoops",
                column: "BusRouteId",
                principalTable: "BusRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
