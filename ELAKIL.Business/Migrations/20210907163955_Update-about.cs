using Microsoft.EntityFrameworkCore.Migrations;

namespace ELAKIL.Business.Migrations
{
    public partial class Updateabout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2999e179-e26c-4fd2-8e46-1c36faa5a0f1", "AQAAAAEAACcQAAAAEFuCdF9YS1omzkH8AoDFrzynSJKRPqcN1Um1dVpNRWIu9iQ9oo9uTGSlKYWRmNFJIg==", "40a744e9-4eb5-44ff-9bd8-cd6017255fde" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Abouts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2dfce8b7-c0aa-4592-a703-4a5af2450b81", "AQAAAAEAACcQAAAAEHUSNzqURDr8lstYaS22sTpbdl4q8fNskb9Au6qhxBIu3xmK6tuO4HtaXlXZ5YfWQw==", "dcf0daa1-a58d-43a6-9827-fe23b6be8ed6" });
        }
    }
}