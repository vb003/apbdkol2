using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace kol2.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Racers",
                columns: new[] { "RacerId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "John", "Doe" },
                    { 2, "Jane", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "RaceId", "Date", "Location", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "warsaw", "best race" },
                    { 2, new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "london", "second best race" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "TrackId", "LengthInKm", "Name" },
                values: new object[,]
                {
                    { 1, 20m, "first track" },
                    { 2, 33m, "second track" }
                });

            migrationBuilder.InsertData(
                table: "Track_Race",
                columns: new[] { "TrackRaceId", "BestTimeInSeconds", "Laps", "RaceId", "TrackId" },
                values: new object[,]
                {
                    { 1, 100, 3, 1, 1 },
                    { 2, null, 5, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Race_Participation",
                columns: new[] { "RacerId", "TrackRaceId", "FinishTimeInSeconds", "Position" },
                values: new object[,]
                {
                    { 1, 1, 5, 5 },
                    { 1, 2, 50, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Race_Participation",
                keyColumns: new[] { "RacerId", "TrackRaceId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Race_Participation",
                keyColumns: new[] { "RacerId", "TrackRaceId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Racers",
                keyColumn: "RacerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Racers",
                keyColumn: "RacerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Track_Race",
                keyColumn: "TrackRaceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Track_Race",
                keyColumn: "TrackRaceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackId",
                keyValue: 2);
        }
    }
}
