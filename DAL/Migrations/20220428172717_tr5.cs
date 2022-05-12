using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class tr5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Suppliers_SupplierId",
                table: "Supplies");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Supplies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "SupplierData",
                table: "Supplies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Suppliers_SupplierId",
                table: "Supplies",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Suppliers_SupplierId",
                table: "Supplies");

            migrationBuilder.DropColumn(
                name: "SupplierData",
                table: "Supplies");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Supplies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Suppliers_SupplierId",
                table: "Supplies",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
