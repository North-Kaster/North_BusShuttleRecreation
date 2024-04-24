using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusShuttleMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_BusLoops_BusLoopId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_BusStops_BusStopId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_BusLoopId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_BusStopId",
                table: "Entries");

            migrationBuilder.AddColumn<string>(
                name: "Driver",
                table: "Entries",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Driver",
                table: "Entries");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_BusLoopId",
                table: "Entries",
                column: "BusLoopId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_BusStopId",
                table: "Entries",
                column: "BusStopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_BusLoops_BusLoopId",
                table: "Entries",
                column: "BusLoopId",
                principalTable: "BusLoops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_BusStops_BusStopId",
                table: "Entries",
                column: "BusStopId",
                principalTable: "BusStops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
