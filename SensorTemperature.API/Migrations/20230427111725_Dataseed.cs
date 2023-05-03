using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SensorTemperature.API.Migrations
{
    /// <inheritdoc />
    public partial class Dataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomSensors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Room 1" },
                    { 2, "Room 2" }
                });

            migrationBuilder.InsertData(
                table: "Temperatures",
                columns: new[] { "Id", "Celsius", "RoomSensorId" },
                values: new object[,]
                {
                    { 1, 60, 1 },
                    { 2, 90, 1 },
                    { 3, 70, 2 },
                    { 4, 80, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Temperatures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Temperatures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Temperatures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Temperatures",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomSensors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomSensors",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
