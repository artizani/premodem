using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "premodem.customer.store",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false),
                    storeCode = table.Column<int>(nullable: false),
                    storeName = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_premodem.customer.store", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "premodem.expense.category",
                columns: table => new
                {
                    name = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    id = table.Column<int>(nullable: false),
                    partId = table.Column<int>(nullable: true),
                    catId = table.Column<int>(nullable: true),
                    description = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    energyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_premodem.expense.category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "premodem.expense.item",
                columns: table => new
                {
                    name = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    id = table.Column<int>(nullable: false),
                    description = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_premodem.expense.item", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "premodem.org",
                columns: table => new
                {
                    orgname = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    address = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    contact = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    id = table.Column<int>(nullable: false),
                    accountnumber = table.Column<int>(nullable: true),
                    bank = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    description = table.Column<string>(unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_premodem.org", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "premodem.people",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    firstname = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    lastname = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    roles = table.Column<int>(nullable: true),
                    email = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    mobile_one = table.Column<int>(nullable: true),
                    mobile_two = table.Column<int>(nullable: true),
                    mobile_three = table.Column<int>(nullable: true),
                    mobile_four = table.Column<int>(nullable: true),
                    orgId = table.Column<int>(nullable: true),
                    bank = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    account = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_premodem.people", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "premodem.deliveryrate",
                columns: table => new
                {
                    storeId = table.Column<int>(nullable: true),
                    id = table.Column<int>(nullable: false),
                    rate = table.Column<decimal>(type: "money", nullable: true),
                    supplier = table.Column<int>(nullable: true),
                    active = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_premodem.deliveryrate", x => x.id);
                    table.ForeignKey(
                        name: "Fk_premodem.deliveryrate_premodem.org",
                        column: x => x.supplier,
                        principalTable: "premodem.org",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "premodem.invoice.delivery",
                columns: table => new
                {
                    number = table.Column<int>(nullable: true),
                    invdate = table.Column<DateTime>(type: "date", nullable: true),
                    storecode = table.Column<int>(nullable: true),
                    quantity = table.Column<int>(nullable: true),
                    grn = table.Column<int>(nullable: true),
                    amount = table.Column<decimal>(type: "money", nullable: true),
                    supplier = table.Column<int>(nullable: true),
                    comments = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_premodem.invoice.delivery", x => x.id);
                    table.ForeignKey(
                        name: "Fk_premodem.invoice.delivery_premodem.org",
                        column: x => x.supplier,
                        principalTable: "premodem.org",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "premodem.expense",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime", nullable: true),
                    amount = table.Column<decimal>(type: "money", nullable: true),
                    item = table.Column<int>(nullable: true),
                    personnel = table.Column<int>(nullable: false),
                    title = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    description = table.Column<string>(maxLength: 500, nullable: true),
                    labour = table.Column<decimal>(type: "money", nullable: true),
                    paidfrom = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    settledDate = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_premodem.expense", x => x.id);
                    table.ForeignKey(
                        name: "Fk_premodem.expense_premodem.expense.category",
                        column: x => x.item,
                        principalTable: "premodem.expense.category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_premodem.expense_premodem.people",
                        column: x => x.personnel,
                        principalTable: "premodem.people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "premodem.generator",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    slacktime = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    channel = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    user = table.Column<int>(nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    counter = table.Column<decimal>(type: "numeric(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_premodem.generator", x => x.id);
                    table.ForeignKey(
                        name: "Fk_premodem.generator_premodem.people",
                        column: x => x.user,
                        principalTable: "premodem.people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "premodem.energy",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    item = table.Column<int>(nullable: true),
                    rate = table.Column<decimal>(type: "money", nullable: true),
                    unit = table.Column<int>(nullable: true),
                    quantity = table.Column<int>(nullable: true),
                    expenseId = table.Column<int>(nullable: true),
                    supplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_premodem.energy", x => x.id);
                    table.ForeignKey(
                        name: "Fk_premodem.energy_premodem.expense",
                        column: x => x.expenseId,
                        principalTable: "premodem.expense",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "premodem.parts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    name = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    item = table.Column<int>(nullable: true),
                    type = table.Column<int>(nullable: true),
                    cost = table.Column<decimal>(type: "money", nullable: true),
                    description = table.Column<string>(maxLength: 256, nullable: true),
                    expenseid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_premodem.parts", x => x.id);
                    table.ForeignKey(
                        name: "Fk_premodem.parts_premodem.expense",
                        column: x => x.expenseid,
                        principalTable: "premodem.expense",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "premodem.customer.store_storeCode_uindex",
                table: "premodem.customer.store",
                column: "storeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_premodem.deliveryrate_supplier",
                table: "premodem.deliveryrate",
                column: "supplier");

            migrationBuilder.CreateIndex(
                name: "IX_premodem.energy_expenseId",
                table: "premodem.energy",
                column: "expenseId");

            migrationBuilder.CreateIndex(
                name: "premodem.energy_id_uindex",
                table: "premodem.energy",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Unq_premodem.expense_amount",
                table: "premodem.expense",
                column: "amount",
                unique: true,
                filter: "[amount] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "Unq_premodem.expense_item",
                table: "premodem.expense",
                column: "item",
                unique: true,
                filter: "[item] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_premodem.expense_personnel",
                table: "premodem.expense",
                column: "personnel");

            migrationBuilder.CreateIndex(
                name: "premodem.expense.category_id_uindex",
                table: "premodem.expense.category",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "premodem.expense.item_id_uindex",
                table: "premodem.expense.item",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "premodem.generator_id_uindex",
                table: "premodem.generator",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_premodem.generator_user",
                table: "premodem.generator",
                column: "user");

            migrationBuilder.CreateIndex(
                name: "Unq_premodem.invoice.delivery_storecode",
                table: "premodem.invoice.delivery",
                column: "storecode",
                unique: true,
                filter: "[storecode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_premodem.invoice.delivery_supplier",
                table: "premodem.invoice.delivery",
                column: "supplier");

            migrationBuilder.CreateIndex(
                name: "IX_premodem.parts_expenseid",
                table: "premodem.parts",
                column: "expenseid");

            migrationBuilder.CreateIndex(
                name: "premodem.parts_id_uindex",
                table: "premodem.parts",
                column: "id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "premodem.customer.store");

            migrationBuilder.DropTable(
                name: "premodem.deliveryrate");

            migrationBuilder.DropTable(
                name: "premodem.energy");

            migrationBuilder.DropTable(
                name: "premodem.expense.item");

            migrationBuilder.DropTable(
                name: "premodem.generator");

            migrationBuilder.DropTable(
                name: "premodem.invoice.delivery");

            migrationBuilder.DropTable(
                name: "premodem.parts");

            migrationBuilder.DropTable(
                name: "premodem.org");

            migrationBuilder.DropTable(
                name: "premodem.expense");

            migrationBuilder.DropTable(
                name: "premodem.expense.category");

            migrationBuilder.DropTable(
                name: "premodem.people");
        }
    }
}
