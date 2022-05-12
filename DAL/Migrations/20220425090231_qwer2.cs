using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class qwer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BonusCards_AspNetUsers_UserId1",
                table: "BonusCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Checks_AspNetUsers_UserId1",
                table: "Checks");

            migrationBuilder.DropIndex(
                name: "IX_Checks_UserId1",
                table: "Checks");

            migrationBuilder.DropIndex(
                name: "IX_BonusCards_UserId1",
                table: "BonusCards");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Checks");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "BonusCards");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Checks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BonusCards",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_UserId",
                table: "Checks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BonusCards_UserId",
                table: "BonusCards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BonusCards_AspNetUsers_UserId",
                table: "BonusCards",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_AspNetUsers_UserId",
                table: "Checks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BonusCards_AspNetUsers_UserId",
                table: "BonusCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Checks_AspNetUsers_UserId",
                table: "Checks");

            migrationBuilder.DropIndex(
                name: "IX_Checks_UserId",
                table: "Checks");

            migrationBuilder.DropIndex(
                name: "IX_BonusCards_UserId",
                table: "BonusCards");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Checks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Checks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BonusCards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "BonusCards",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checks_UserId1",
                table: "Checks",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_BonusCards_UserId1",
                table: "BonusCards",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BonusCards_AspNetUsers_UserId1",
                table: "BonusCards",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_AspNetUsers_UserId1",
                table: "Checks",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
