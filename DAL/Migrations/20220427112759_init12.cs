using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class init12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckForProduct_Checks_CheckID",
                table: "CheckForProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckForProduct_Products_ProductID",
                table: "CheckForProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Suppliers_SupplierID",
                table: "Supplies");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplyForProduct_Products_ProductID",
                table: "SupplyForProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplyForProduct_Supplies_SupplyID",
                table: "SupplyForProduct");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "SupplyForProduct",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "SupplyID",
                table: "SupplyForProduct",
                newName: "SupplyId");

            migrationBuilder.RenameIndex(
                name: "IX_SupplyForProduct_ProductID",
                table: "SupplyForProduct",
                newName: "IX_SupplyForProduct_ProductId");

            migrationBuilder.RenameColumn(
                name: "SupplierID",
                table: "Supplies",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "SupplyID",
                table: "Supplies",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Supplies_SupplierID",
                table: "Supplies",
                newName: "IX_Supplies_SupplierId");

            migrationBuilder.RenameColumn(
                name: "SupplierID",
                table: "Suppliers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductTypeID",
                table: "ProductTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DiscountID",
                table: "Discounts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CheckId",
                table: "Checks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "CheckForProduct",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "CheckID",
                table: "CheckForProduct",
                newName: "CheckId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckForProduct_ProductID",
                table: "CheckForProduct",
                newName: "IX_CheckForProduct_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckForProduct_Checks_CheckId",
                table: "CheckForProduct",
                column: "CheckId",
                principalTable: "Checks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckForProduct_Products_ProductId",
                table: "CheckForProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Suppliers_SupplierId",
                table: "Supplies",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplyForProduct_Products_ProductId",
                table: "SupplyForProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplyForProduct_Supplies_SupplyId",
                table: "SupplyForProduct",
                column: "SupplyId",
                principalTable: "Supplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckForProduct_Checks_CheckId",
                table: "CheckForProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckForProduct_Products_ProductId",
                table: "CheckForProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Suppliers_SupplierId",
                table: "Supplies");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplyForProduct_Products_ProductId",
                table: "SupplyForProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplyForProduct_Supplies_SupplyId",
                table: "SupplyForProduct");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "SupplyForProduct",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "SupplyId",
                table: "SupplyForProduct",
                newName: "SupplyID");

            migrationBuilder.RenameIndex(
                name: "IX_SupplyForProduct_ProductId",
                table: "SupplyForProduct",
                newName: "IX_SupplyForProduct_ProductID");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "Supplies",
                newName: "SupplierID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Supplies",
                newName: "SupplyID");

            migrationBuilder.RenameIndex(
                name: "IX_Supplies_SupplierId",
                table: "Supplies",
                newName: "IX_Supplies_SupplierID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Suppliers",
                newName: "SupplierID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductTypes",
                newName: "ProductTypeID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Discounts",
                newName: "DiscountID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Checks",
                newName: "CheckId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CheckForProduct",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "CheckId",
                table: "CheckForProduct",
                newName: "CheckID");

            migrationBuilder.RenameIndex(
                name: "IX_CheckForProduct_ProductId",
                table: "CheckForProduct",
                newName: "IX_CheckForProduct_ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckForProduct_Checks_CheckID",
                table: "CheckForProduct",
                column: "CheckID",
                principalTable: "Checks",
                principalColumn: "CheckId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckForProduct_Products_ProductID",
                table: "CheckForProduct",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Suppliers_SupplierID",
                table: "Supplies",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplyForProduct_Products_ProductID",
                table: "SupplyForProduct",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplyForProduct_Supplies_SupplyID",
                table: "SupplyForProduct",
                column: "SupplyID",
                principalTable: "Supplies",
                principalColumn: "SupplyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
