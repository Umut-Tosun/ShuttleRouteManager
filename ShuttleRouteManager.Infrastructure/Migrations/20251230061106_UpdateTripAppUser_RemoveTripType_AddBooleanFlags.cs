using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleRouteManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTripAppUser_RemoveTripType_AddBooleanFlags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TripAppUsers_AppUserId_RouteId_TripType",
                table: "TripAppUsers");

            migrationBuilder.DropColumn(
                name: "TripType",
                table: "TripAppUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsEveningTripActive",
                table: "TripAppUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMorningTripActive",
                table: "TripAppUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_TripAppUser_User_Route_TripTypes",
                table: "TripAppUsers",
                columns: new[] { "AppUserId", "RouteId", "IsMorningTripActive", "IsEveningTripActive" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TripAppUser_User_Route_TripTypes",
                table: "TripAppUsers");

            migrationBuilder.DropColumn(
                name: "IsEveningTripActive",
                table: "TripAppUsers");

            migrationBuilder.DropColumn(
                name: "IsMorningTripActive",
                table: "TripAppUsers");

            migrationBuilder.AddColumn<string>(
                name: "TripType",
                table: "TripAppUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TripAppUsers_AppUserId_RouteId_TripType",
                table: "TripAppUsers",
                columns: new[] { "AppUserId", "RouteId", "TripType" });
        }
    }
}
