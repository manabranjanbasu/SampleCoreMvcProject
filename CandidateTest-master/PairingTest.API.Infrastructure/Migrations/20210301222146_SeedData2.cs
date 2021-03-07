using Microsoft.EntityFrameworkCore.Migrations;

namespace PairingTest.API.Infrastructure.Migrations
{
    public partial class SeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuestionOption",
                columns: new[] { "Id", "QuestionID", "QuestionsText" },
                values: new object[,]
                {
                    { 1L, 1L, "What is the capital of Cuba?" },
                    { 2L, 1L, "What is the capital of France?" },
                    { 3L, 1L, "What is the capital of Poland?" },
                    { 4L, 1L, "What is the capital of Germany?" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuestionOption",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "QuestionOption",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "QuestionOption",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "QuestionOption",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
