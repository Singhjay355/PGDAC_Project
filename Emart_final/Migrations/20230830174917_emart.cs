using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emart_final.Migrations
{
    /// <inheritdoc />
    public partial class emart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    catmasterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    childflag = table.Column<bool>(type: "bit", nullable: false),
                    parentCatID = table.Column<int>(type: "int", nullable: false),
                    catImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.catmasterID);
                });

            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    ConfigID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    configname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.ConfigID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    prodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prodShortDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prodLongDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mrpPrice = table.Column<double>(type: "float", nullable: false),
                    offerPrice = table.Column<double>(type: "float", nullable: false),
                    cardHolderPrice = table.Column<double>(type: "float", nullable: false),
                    pointsRedeem = table.Column<int>(type: "int", nullable: false),
                    imgPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inventoryQuantity = table.Column<int>(type: "int", nullable: false),
                    catmasterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.prodID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_catmasterID",
                        column: x => x.catmasterID,
                        principalTable: "Categories",
                        principalColumn: "catmasterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustID = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    DeliveryCharges = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    TotalBill = table.Column<double>(type: "float", nullable: false),
                    ProdID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProdID",
                        column: x => x.ProdID,
                        principalTable: "Products",
                        principalColumn: "prodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfigDetails",
                columns: table => new
                {
                    configDetailsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    configID = table.Column<int>(type: "int", nullable: false),
                    configDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigDetails", x => x.configDetailsID);
                    table.ForeignKey(
                        name: "FK_ConfigDetails_Configs_configID",
                        column: x => x.configID,
                        principalTable: "Configs",
                        principalColumn: "ConfigID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigDetails_Products_prodID",
                        column: x => x.prodID,
                        principalTable: "Products",
                        principalColumn: "prodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    custId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    custName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    custAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    custPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    custEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    custPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cardHolder = table.Column<bool>(type: "bit", nullable: false),
                    points = table.Column<int>(type: "int", nullable: false),
                    CartID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.custId);
                    table.ForeignKey(
                        name: "FK_Customers_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "CartID");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmt = table.Column<double>(type: "float", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false),
                    DeliveryCharge = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    TotalBill = table.Column<double>(type: "float", nullable: false),
                    CustID = table.Column<int>(type: "int", nullable: false),
                    CustomercustId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomercustId",
                        column: x => x.CustomercustId,
                        principalTable: "Customers",
                        principalColumn: "custId");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    InvoiceDtID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MRP = table.Column<double>(type: "float", nullable: false),
                    CardHolderPrice = table.Column<double>(type: "float", nullable: false),
                    PointsRedeem = table.Column<int>(type: "int", nullable: false),
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    ProdID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.InvoiceDtID);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Products_ProdID",
                        column: x => x.ProdID,
                        principalTable: "Products",
                        principalColumn: "prodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deliverydate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustID = table.Column<int>(type: "int", nullable: false),
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustID",
                        column: x => x.CustID,
                        principalTable: "Customers",
                        principalColumn: "custId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProdID",
                table: "Carts",
                column: "ProdID");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigDetails_configID",
                table: "ConfigDetails",
                column: "configID");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigDetails_prodID",
                table: "ConfigDetails",
                column: "prodID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CartID",
                table: "Customers",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceID",
                table: "InvoiceDetails",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ProdID",
                table: "InvoiceDetails",
                column: "ProdID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomercustId",
                table: "Invoices",
                column: "CustomercustId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustID",
                table: "Orders",
                column: "CustID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InvoiceID",
                table: "Orders",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_catmasterID",
                table: "Products",
                column: "catmasterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigDetails");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
