using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class initdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_CartStatus",
                columns: table => new
                {
                    CartStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartStatus = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Cart__031908A883A023C5", x => x.CartStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Cate__19093A0BFB63B2AA", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_MemberRole",
                columns: table => new
                {
                    MemberRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Memb__673C212BC88BBDD8", x => x.MemberRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    LastName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    EmailId = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Memb__0CF04B18B488BEA9", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Role__8AFACE1AFCB9D533", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Description = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProductImage = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Prod__B40CC6CD9CB96165", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK__Tbl_Produ__Categ__286302EC",
                        column: x => x.CategoryId,
                        principalTable: "Tbl_Category",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ShippingDetails",
                columns: table => new
                {
                    ShippingDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    Adress = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Country = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    PaymentType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Ship__FBB368517F3A09A5", x => x.ShippingDetailId);
                    table.ForeignKey(
                        name: "FK__Tbl_Shipp__Membe__300424B4",
                        column: x => x.MemberId,
                        principalTable: "Tbl_Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    CartStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Cart__51BCD7B70C15C5A0", x => x.CartId);
                    table.ForeignKey(
                        name: "FK__Tbl_Cart__Produc__35BCFE0A",
                        column: x => x.ProductId,
                        principalTable: "Tbl_Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Cart_ProductId",
                table: "Tbl_Cart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "UQ__Tbl_Cate__8517B2E04A69117E",
                table: "Tbl_Category",
                column: "CategoryName",
                unique: true,
                filter: "[CategoryName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Tbl_Memb__7ED91ACEEF8ADB7F",
                table: "Tbl_Members",
                column: "EmailId",
                unique: true,
                filter: "[EmailId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Product_CategoryId",
                table: "Tbl_Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "UQ__Tbl_Prod__DD5A978A35B6DF84",
                table: "Tbl_Product",
                column: "ProductName",
                unique: true,
                filter: "[ProductName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Tbl_Role__8A2B6160E015BBDE",
                table: "Tbl_Roles",
                column: "RoleName",
                unique: true,
                filter: "[RoleName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ShippingDetails_MemberId",
                table: "Tbl_ShippingDetails",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Cart");

            migrationBuilder.DropTable(
                name: "Tbl_CartStatus");

            migrationBuilder.DropTable(
                name: "Tbl_MemberRole");

            migrationBuilder.DropTable(
                name: "Tbl_Roles");

            migrationBuilder.DropTable(
                name: "Tbl_ShippingDetails");

            migrationBuilder.DropTable(
                name: "Tbl_Product");

            migrationBuilder.DropTable(
                name: "Tbl_Members");

            migrationBuilder.DropTable(
                name: "Tbl_Category");
        }
    }
}
