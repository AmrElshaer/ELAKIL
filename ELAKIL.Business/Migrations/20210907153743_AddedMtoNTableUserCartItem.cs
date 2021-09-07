using Microsoft.EntityFrameworkCore.Migrations;

namespace ELAKIL.Business.Migrations
{
    public partial class AddedMtoNTableUserCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCartItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    MealID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCartItems", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c80defda-a5c5-4b69-b255-8b440af68b17", "AQAAAAEAACcQAAAAEPuUTlbgESUuU/vlPLH9ENx5X9zngznTLDH7tV1ktuZiMHqnVm6WoGFkDfaEH37wGQ==", "087e0ef3-63c1-44a5-a404-cc4483b43e6e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCartItems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2dfce8b7-c0aa-4592-a703-4a5af2450b81", "AQAAAAEAACcQAAAAEHUSNzqURDr8lstYaS22sTpbdl4q8fNskb9Au6qhxBIu3xmK6tuO4HtaXlXZ5YfWQw==", "dcf0daa1-a58d-43a6-9827-fe23b6be8ed6" });
        }
    }
}
