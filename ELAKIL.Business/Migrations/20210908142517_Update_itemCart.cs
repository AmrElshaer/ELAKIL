using Microsoft.EntityFrameworkCore.Migrations;

namespace ELAKIL.Business.Migrations
{
    public partial class Update_itemCart : Migration
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
                    MealId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCartItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserCartItems_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d697f38c-567a-4daf-bfb2-d89114787c3f", "AQAAAAEAACcQAAAAEFvepH8LVn9Kx/QxTIKtfVz9av+6JFVFMLqzU7WeUfrKlECdVB9mp6QVcch6csslWQ==", "ffb6b590-0806-498d-b850-9ae2f40d51ba" });

            migrationBuilder.CreateIndex(
                name: "IX_UserCartItems_MealId",
                table: "UserCartItems",
                column: "MealId");
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
                values: new object[] { "2999e179-e26c-4fd2-8e46-1c36faa5a0f1", "AQAAAAEAACcQAAAAEFuCdF9YS1omzkH8AoDFrzynSJKRPqcN1Um1dVpNRWIu9iQ9oo9uTGSlKYWRmNFJIg==", "40a744e9-4eb5-44ff-9bd8-cd6017255fde" });
        }
    }
}