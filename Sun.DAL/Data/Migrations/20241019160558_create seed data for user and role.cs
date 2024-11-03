using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sun.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class createseeddataforuserandrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33f9091b-4212-4157-8834-040b994fe73d", null, "SuperAdmin", "SUPERADMIN" },
                    { "65595cb9-7c50-41c1-9b03-7f77ef446763", null, "User", "USER" },
                    { "eca0bbe8-b2c4-4e8f-9d80-b7e8d7565b96", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "729dd08f-6b8a-49ec-8256-e8edc6400381", 0, null, "4ebdae34-8815-4dec-8991-6057689be186", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEIma6gLI3+cFSZpLFY5UH7hLmgzLblP4PrRL32WwcKArF5w8IMFnHGgGU0KOqybVXw==", null, null, false, "8798c7e2-ccf2-41d5-bd27-581f8574ef81", false, "admin@admin.com" },
                    { "7a3f1c57-3aed-4db8-8da0-ae44522219b7", 0, null, "752a01ac-1f5d-4ff7-b768-a200cf80b9ea", "superadmin@superadmin.com", true, false, null, "SUPERADMIN@SUPERADMIN.COM", "SUPERADMIN@SUPERADMIN.COM", "AQAAAAIAAYagAAAAECZ9c614QPjOTNCReVTcRu3rezXnapUj4spVIr9dIuyMG0ouPlG0GuIThJwSu4BRzw==", null, null, false, "0902e6cf-558e-4cba-9072-a2a5be3df451", false, "superadmin@superadmin.com" },
                    { "c77f5fc3-e604-4a0b-bbda-69d36428d98b", 0, null, "a02689dd-5ebf-4718-ac7c-ab1a9b7acbbd", "user@user.com", true, false, null, "USER@USER.COM", "USER@USER.COM", "AQAAAAIAAYagAAAAEASJ9j61cWpiCq4MX0AZzsMFZzkTEXy7gtk+G3yluUJCd5iFDHSYn8GvxaO+cvkBxw==", null, null, false, "e778a207-07f1-415a-b987-0a966b487109", false, "user@user.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "eca0bbe8-b2c4-4e8f-9d80-b7e8d7565b96", "729dd08f-6b8a-49ec-8256-e8edc6400381" },
                    { "33f9091b-4212-4157-8834-040b994fe73d", "7a3f1c57-3aed-4db8-8da0-ae44522219b7" },
                    { "65595cb9-7c50-41c1-9b03-7f77ef446763", "c77f5fc3-e604-4a0b-bbda-69d36428d98b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eca0bbe8-b2c4-4e8f-9d80-b7e8d7565b96", "729dd08f-6b8a-49ec-8256-e8edc6400381" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "33f9091b-4212-4157-8834-040b994fe73d", "7a3f1c57-3aed-4db8-8da0-ae44522219b7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65595cb9-7c50-41c1-9b03-7f77ef446763", "c77f5fc3-e604-4a0b-bbda-69d36428d98b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33f9091b-4212-4157-8834-040b994fe73d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65595cb9-7c50-41c1-9b03-7f77ef446763");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eca0bbe8-b2c4-4e8f-9d80-b7e8d7565b96");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "729dd08f-6b8a-49ec-8256-e8edc6400381");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a3f1c57-3aed-4db8-8da0-ae44522219b7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c77f5fc3-e604-4a0b-bbda-69d36428d98b");
        }
    }
}
