using Microsoft.EntityFrameworkCore.Migrations;

namespace ELAKIL.Business.Migrations
{
    public partial class AddDescCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a68be0bc-57b7-4f67-972b-c91909c725f5", "AQAAAAEAACcQAAAAEFCvuA2QHz53+QCpKbChSW0vI5NATTsPS1nIkJ0iHuGfJf8CBYMvxD71d+MYPqLufQ==", "eedfce2e-5dc7-49a7-9b6b-f6981086bb62" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c7c442d-8465-4ff8-9d4a-76cac76021e0", "AQAAAAEAACcQAAAAEFDlxqWtnvFyRVEoqgXrayCAFgFCr5qZKSxAQYxJ1AM463PFs4Z7/0L1T9TajyhcCA==", "daa97e77-daef-417b-9031-e4ebe74b51b7" });
        }
    }
}