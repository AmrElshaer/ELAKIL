using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ELAKIL.Business.Migrations
{
    public partial class Update_UpdateOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliverDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d52ae186-b052-4ae8-bce9-3759710587b0", "AQAAAAEAACcQAAAAEPSz2j9hPaydNbcQc9Nc7kTpWWQ/m7qtg8Wju+gMI/GumaMkwK9nyeV9irFTlazMOg==", "315f9365-a295-4cbe-a6fc-34502545cbdf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliverDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25f24a4a-0f85-4b7b-be2c-5ab151001526", "AQAAAAEAACcQAAAAEGxo0QRHBXRf7fRgAOWZ4UhKqT6nBxx2u2Zmd7UtnMSKBpO3FC/sbbZtaUNTqrXyyw==", "da863d04-b093-4758-8f23-7ace8c25641c" });
        }
    }
}
