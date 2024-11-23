using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Migrations
{
    /// <inheritdoc />
    public partial class editAvailableRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ReportDetails_ReportDetailsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ReportDetailsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReportDetailsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AvailableRooms",
                table: "RoomTypes");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ReportDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetails_UserId",
                table: "ReportDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportDetails_Users_UserId",
                table: "ReportDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportDetails_Users_UserId",
                table: "ReportDetails");

            migrationBuilder.DropIndex(
                name: "IX_ReportDetails_UserId",
                table: "ReportDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ReportDetails");

            migrationBuilder.AddColumn<int>(
                name: "ReportDetailsId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AvailableRooms",
                table: "RoomTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "Hotels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ReportDetailsId",
                table: "Users",
                column: "ReportDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ReportDetails_ReportDetailsId",
                table: "Users",
                column: "ReportDetailsId",
                principalTable: "ReportDetails",
                principalColumn: "Id");
        }
    }
}
