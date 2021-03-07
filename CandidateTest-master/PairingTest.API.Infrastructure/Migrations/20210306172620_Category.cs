using Microsoft.EntityFrameworkCore.Migrations;

namespace PairingTest.API.Infrastructure.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Question",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrectAnswer",
                table: "QuestionOption",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Question",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_CategoryId",
                table: "Question",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Category_CategoryId",
                table: "Question",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Category_CategoryId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Question_CategoryId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "IsCorrectAnswer",
                table: "QuestionOption");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Question");

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "QuestionnaireTitle" },
                values: new object[] { 1L, "Geography Questions" });

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
    }
}
