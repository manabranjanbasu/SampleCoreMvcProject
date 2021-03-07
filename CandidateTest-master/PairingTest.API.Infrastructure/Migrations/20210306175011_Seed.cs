using Microsoft.EntityFrameworkCore.Migrations;

namespace PairingTest.API.Infrastructure.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionsText",
                table: "QuestionOption",
                newName: "OptionText");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 1L, "Geography Questions" });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "CategoryId", "QuestionnaireTitle" },
                values: new object[,]
                {
                    { 1L, 1L, "What is the capital of Cuba?" },
                    { 2L, 1L, "What is the capital of France?" },
                    { 3L, 1L, "What is the capital of Poland?" },
                    { 4L, 1L, "What is the capital of Germany?" }
                });

            migrationBuilder.InsertData(
                table: "QuestionOption",
                columns: new[] { "Id", "IsCorrectAnswer", "OptionText", "QuestionID" },
                values: new object[,]
                {
                    { 1L, true, "Havana", 1L },
                    { 2L, false, "Paris", 1L },
                    { 3L, false, "Warsaw", 1L },
                    { 4L, false, "Berlin", 1L },
                    { 5L, false, "Havana", 2L },
                    { 6L, true, "Paris", 2L },
                    { 7L, false, "Warsaw", 2L },
                    { 8L, false, "Berlin", 2L },
                    { 9L, false, "Havana", 3L },
                    { 10L, false, "Paris", 3L },
                    { 11L, true, "Warsaw", 3L },
                    { 12L, false, "Berlin", 3L },
                    { 13L, false, "Havana", 4L },
                    { 14L, false, "Paris", 4L },
                    { 15L, false, "Warsaw", 4L },
                    { 16L, true, "Berlin", 4L }
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

            migrationBuilder.DeleteData(
                table: "QuestionOption",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "QuestionOption",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "QuestionOption",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "QuestionOption",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "QuestionOption",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "QuestionOption",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "QuestionOption",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "QuestionOption",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "QuestionOption",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "QuestionOption",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "QuestionOption",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "QuestionOption",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.RenameColumn(
                name: "OptionText",
                table: "QuestionOption",
                newName: "QuestionsText");
        }
    }
}
