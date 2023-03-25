using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MottoAdver.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class helperMigrat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    district = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    postalCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("address_pr", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    passwordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passwordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tellNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    telegramId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    refreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    refreshTokenExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("admin_prKey", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                    table.UniqueConstraint("Email", x => x.email)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Motos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    motoName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    charge = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    distanceFullCharge = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    maxWeight = table.Column<long>(type: "bigint", nullable: false),
                    maxSpeed = table.Column<int>(type: "int", nullable: false),
                    makingYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("moto_pk", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Addvertisements",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    addvertiserFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    addvertiserTelegramId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addvertiserTellNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    motoPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    addressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    motoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("addver_pk", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Addvertisements_Addresses_addressId",
                        column: x => x.addressId,
                        principalTable: "Addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addvertisements_Motos_motoId",
                        column: x => x.motoId,
                        principalTable: "Motos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "id", "email", "fullName", "passwordHash", "passwordSalt", "refreshToken", "refreshTokenExpireDate", "telegramId", "tellNumber" },
                values: new object[] { new Guid("a500fe8d-d670-4aec-95bf-600075b28d7c"), "pdp@gmail.com", "Jasurbek Mamatqulov", "54uOihn/eEus6GsI75wcM759fVfUSlN0/qtD9g8ah34=", "d6556ded-ca2f-41ca-823d-30af7381fb39", null, null, "@Jasurbek_dveloper", "+998931235896" });

            migrationBuilder.CreateIndex(
                name: "IX_Addvertisements_addressId",
                table: "Addvertisements",
                column: "addressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addvertisements_motoId",
                table: "Addvertisements",
                column: "motoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addvertisements");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Motos");
        }
    }
}
