using Microsoft.EntityFrameworkCore.Migrations;

namespace ELAKIL.Business.Migrations
{
    public partial class Update_AddQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "UserCartItems",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25f24a4a-0f85-4b7b-be2c-5ab151001526", "AQAAAAEAACcQAAAAEGxo0QRHBXRf7fRgAOWZ4UhKqT6nBxx2u2Zmd7UtnMSKBpO3FC/sbbZtaUNTqrXyyw==", "da863d04-b093-4758-8f23-7ace8c25641c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "UserCartItems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d697f38c-567a-4daf-bfb2-d89114787c3f", "AQAAAAEAACcQAAAAEFvepH8LVn9Kx/QxTIKtfVz9av+6JFVFMLqzU7WeUfrKlECdVB9mp6QVcch6csslWQ==", "ffb6b590-0806-498d-b850-9ae2f40d51ba" });
        }
    }
}