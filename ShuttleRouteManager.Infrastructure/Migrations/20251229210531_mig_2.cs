using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleRouteManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DefaultDriverId",
                table: "Buses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buses_DefaultDriverId",
                table: "Buses",
                column: "DefaultDriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_Drivers_DefaultDriverId",
                table: "Buses",
                column: "DefaultDriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buses_Drivers_DefaultDriverId",
                table: "Buses");

            migrationBuilder.DropIndex(
                name: "IX_Buses_DefaultDriverId",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "DefaultDriverId",
                table: "Buses");
        }
    }
}
