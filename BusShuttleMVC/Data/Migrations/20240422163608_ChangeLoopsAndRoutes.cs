using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusShuttleMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeLoopsAndRoutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BusRouteId",
                table: "BusLoops",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BusRoute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StopIds = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusRoute", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusLoops_BusRouteId",
                table: "BusLoops",
                column: "BusRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLoops_BusRoute_BusRouteId",
                table: "BusLoops",
                column: "BusRouteId",
                principalTable: "BusRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLoops_BusRoute_BusRouteId",
                table: "BusLoops");

            migrationBuilder.DropTable(
                name: "BusRoute");

            migrationBuilder.DropIndex(
                name: "IX_BusLoops_BusRouteId",
                table: "BusLoops");

            migrationBuilder.DropColumn(
                name: "BusRouteId",
                table: "BusLoops");
        }
    }
}
