using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ELAKIL.Business.Migrations
{
    public partial class InitMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUserProfileId = table.Column<int>(type: "int", nullable: true),
                    ToUserProfileId = table.Column<int>(type: "int", nullable: true),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_UserProfiles_FromUserProfileId",
                        column: x => x.FromUserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_UserProfiles_ToUserProfileId",
                        column: x => x.ToUserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7961bc4a-47eb-4dfd-bb4d-2bcb4b2667a1", "AQAAAAEAACcQAAAAELc3mlNRZja9hwibhCIuN42K1U5dfXYb5iKAyY8hQMVAFK8nMBUQHAkaOqW7mEA/TA==", "e06d3451-afde-47a8-ac5c-5c54847aae22" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromUserProfileId",
                table: "Messages",
                column: "FromUserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToUserProfileId",
                table: "Messages",
                column: "ToUserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d52ae186-b052-4ae8-bce9-3759710587b0", "AQAAAAEAACcQAAAAEPSz2j9hPaydNbcQc9Nc7kTpWWQ/m7qtg8Wju+gMI/GumaMkwK9nyeV9irFTlazMOg==", "315f9365-a295-4cbe-a6fc-34502545cbdf" });
        }
    }
}
