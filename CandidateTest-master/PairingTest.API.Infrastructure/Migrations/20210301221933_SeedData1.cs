using Microsoft.EntityFrameworkCore.Migrations;

namespace PairingTest.API.Infrastructure.Migrations
{
    public partial class SeedData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "QuestionnaireTitle" },
                values: new object[] { 1L, "Geography Questions" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
