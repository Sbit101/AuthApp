using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class mxme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "044f98df-51b4-49ec-9148-583454450268");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "0648524a-a419-4a15-b14b-df42a895d040");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "8edf31d0-3072-4e02-8884-f3431069006b");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b872c83d-583d-4a1d-8006-42f6e1046bbf", "16297838-b7db-4e90-a20b-358e342213b7" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16297838-b7db-4e90-a20b-358e342213b7");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "b872c83d-583d-4a1d-8006-42f6e1046bbf");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BackgroundStory", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureOne", "ProfilePicture", "SecurityStamp", "Specialties", "TwoFactorEnabled", "UserName", "UsernameChangeLimit" },
                values: new object[] { "ed6cabb7-3b7a-439a-b649-73615771e691", 0, null, "1938745e-0293-47c1-9feb-ec1548f0ea1f", "superuser@mail.com", true, "super", "adminuser", false, null, null, "SUPERUSER@MAIL.COM", "AQAAAAEAACcQAAAAELvG8SztEqG9lUyJWU2IWHDZRXvTbo47wOZFdhpkOP9HbJP+1daIwBLh3ZmYInoK3w==", null, false, null, null, "5ecf8162-ad82-4698-b0e1-9599ce3b34bf", null, false, "superuser@mail.com", 10 });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "04951c73-539c-4779-ae1b-4e13e4aba998", "04951c73-539c-4779-ae1b-4e13e4aba998", "Basic", "BASIC" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0bc7a2f7-2bca-4571-b956-6f00b85a0c99", "0bc7a2f7-2bca-4571-b956-6f00b85a0c99", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3eb2b7bd-5a68-4b69-a9e0-d858d6b4d639", "3eb2b7bd-5a68-4b69-a9e0-d858d6b4d639", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f80c0164-3c01-432d-b46e-04388a9348d0", "f80c0164-3c01-432d-b46e-04388a9348d0", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f80c0164-3c01-432d-b46e-04388a9348d0", "ed6cabb7-3b7a-439a-b649-73615771e691" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "04951c73-539c-4779-ae1b-4e13e4aba998");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "0bc7a2f7-2bca-4571-b956-6f00b85a0c99");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "3eb2b7bd-5a68-4b69-a9e0-d858d6b4d639");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f80c0164-3c01-432d-b46e-04388a9348d0", "ed6cabb7-3b7a-439a-b649-73615771e691" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed6cabb7-3b7a-439a-b649-73615771e691");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "f80c0164-3c01-432d-b46e-04388a9348d0");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BackgroundStory", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureOne", "ProfilePicture", "SecurityStamp", "Specialties", "TwoFactorEnabled", "UserName", "UsernameChangeLimit" },
                values: new object[] { "16297838-b7db-4e90-a20b-358e342213b7", 0, null, "7a827a10-509b-4066-8971-57987d7cf5f5", "superuser@mail.com", true, "super", "adminuser", false, null, null, "SUPERUSER@MAIL.COM", "AQAAAAEAACcQAAAAEJs6gIGzihoefQiGA9GNAgGZiA1Yc8qPY42DXZ+eFOi9RBgcYulSGV+B25NiC4CzJw==", null, false, null, null, "21f03ad6-bf8f-4584-8fb1-9d07e592b815", null, false, "superuser@mail.com", 10 });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "044f98df-51b4-49ec-9148-583454450268", "044f98df-51b4-49ec-9148-583454450268", "Basic", "BASIC" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0648524a-a419-4a15-b14b-df42a895d040", "0648524a-a419-4a15-b14b-df42a895d040", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8edf31d0-3072-4e02-8884-f3431069006b", "8edf31d0-3072-4e02-8884-f3431069006b", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b872c83d-583d-4a1d-8006-42f6e1046bbf", "b872c83d-583d-4a1d-8006-42f6e1046bbf", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b872c83d-583d-4a1d-8006-42f6e1046bbf", "16297838-b7db-4e90-a20b-358e342213b7" });
        }
    }
}
