using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusShuttleMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Boarded = table.Column<int>(type: "INTEGER", nullable: false),
                    LeftBehind = table.Column<int>(type: "INTEGER", nullable: false),
                    BusLoopId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BusNumber = table.Column<string>(type: "TEXT", nullable: false),
                    BusStopId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_BusLoops_BusLoopId",
                        column: x => x.BusLoopId,
                        principalTable: "BusLoops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entries_BusStops_BusStopId",
                        column: x => x.BusStopId,
                        principalTable: "BusStops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_BusLoopId",
                table: "Entries",
                column: "BusLoopId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_BusStopId",
                table: "Entries",
                column: "BusStopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
