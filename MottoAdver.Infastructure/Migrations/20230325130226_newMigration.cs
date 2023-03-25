using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MottoAdver.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "id",
                keyValue: new Guid("91b2adff-854c-4bdd-ab24-bf100ddce5ae"));

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "id", "email", "fullName", "passwordHash", "passwordSalt", "refreshToken", "refreshTokenExpireDate", "telegramId", "tellNumber" },
                values: new object[] { new Guid("86081d8e-ce36-49b0-b0a8-c055ba0f4f90"), "pdp@gmail.com", "Jasurbek Mamatqulov", "54uOihn/eEus6GsI75wcM759fVfUSlN0/qtD9g8ah34=", "d6556ded-ca2f-41ca-823d-30af7381fb39", null, null, "@Jasurbek_dveloper", "+998931235896" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "id",
                keyValue: new Guid("86081d8e-ce36-49b0-b0a8-c055ba0f4f90"));

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "id", "email", "fullName", "passwordHash", "passwordSalt", "refreshToken", "refreshTokenExpireDate", "telegramId", "tellNumber" },
                values: new object[] { new Guid("91b2adff-854c-4bdd-ab24-bf100ddce5ae"), "jasurbek@gmail.com", "Jasurbek Mamatqulov", "IiwY2fRjctiX8Wk8fspqirKzdA/maUc4vtM0Dxy9DXE=", "c1e212d0-85e8-4ddb-87a2-9d049756307c", null, null, "@Jasurbek_dveloper", "+998931235896" });
        }
    }
}
