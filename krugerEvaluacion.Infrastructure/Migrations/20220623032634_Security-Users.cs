using Microsoft.EntityFrameworkCore.Migrations;

namespace krugerEvaluacion.Infrastructure.Migrations
{
    public partial class SecurityUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Securities");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Securities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Securities_UserId",
                table: "Securities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Securities_Users_UserId",
                table: "Securities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Securities_Users_UserId",
                table: "Securities");

            migrationBuilder.DropIndex(
                name: "IX_Securities_UserId",
                table: "Securities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Securities");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Securities",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
