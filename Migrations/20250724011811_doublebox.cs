using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class doublebox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "60b2afea-f1a8-41fb-a384-c21cf943e323");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "cd3f901c-d282-40f1-9454-20000f0d44cc");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "ed006433-adf4-4d85-b409-4ef0df916dea");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "428f9f95-fd47-4b86-8850-e750f1f14154", "faac366c-1420-4c88-a9ff-96b708934e08" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "faac366c-1420-4c88-a9ff-96b708934e08");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "428f9f95-fd47-4b86-8850-e750f1f14154");

            migrationBuilder.AlterColumn<double>(
                name: "CompanyPhoneNumber",
                schema: "Identity",
                table: "WelcomeFormDBList",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(uint),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BackgroundStory", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureOne", "ProfilePicture", "SecurityStamp", "Specialties", "TwoFactorEnabled", "UserName", "UsernameChangeLimit" },
                values: new object[] { "49eb4c90-d140-40e3-ab6f-2fbf076799ed", 0, null, "c31ba3f9-6c93-4914-9064-20de7ec9ffc6", "superuser@mail.com", true, "super", "adminuser", false, null, null, "SUPERUSER@MAIL.COM", "AQAAAAEAACcQAAAAELEWnwEWvXX2u0udnPUluV93e2ULH0hV1wW0nKcGZTobez+hTfrZ12q3Rl+fuDNQAA==", null, false, null, null, "e41aa46d-5fd5-48aa-ae0d-856b4d47d94b", null, false, "superuser@mail.com", 10 });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "34a8f56e-bc6b-4760-8e45-a6c86a1b86e4", "34a8f56e-bc6b-4760-8e45-a6c86a1b86e4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7854327a-d55f-4904-8e9b-2847204c3114", "7854327a-d55f-4904-8e9b-2847204c3114", "Basic", "BASIC" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a9adcab2-2613-41d6-ba46-9e9585700eb2", "a9adcab2-2613-41d6-ba46-9e9585700eb2", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af0ab69e-14b6-47f3-abbc-757bcfaf2c14", "af0ab69e-14b6-47f3-abbc-757bcfaf2c14", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a9adcab2-2613-41d6-ba46-9e9585700eb2", "49eb4c90-d140-40e3-ab6f-2fbf076799ed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "34a8f56e-bc6b-4760-8e45-a6c86a1b86e4");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "7854327a-d55f-4904-8e9b-2847204c3114");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "af0ab69e-14b6-47f3-abbc-757bcfaf2c14");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a9adcab2-2613-41d6-ba46-9e9585700eb2", "49eb4c90-d140-40e3-ab6f-2fbf076799ed" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49eb4c90-d140-40e3-ab6f-2fbf076799ed");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "a9adcab2-2613-41d6-ba46-9e9585700eb2");

            migrationBuilder.AlterColumn<uint>(
                name: "CompanyPhoneNumber",
                schema: "Identity",
                table: "WelcomeFormDBList",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BackgroundStory", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureOne", "ProfilePicture", "SecurityStamp", "Specialties", "TwoFactorEnabled", "UserName", "UsernameChangeLimit" },
                values: new object[] { "faac366c-1420-4c88-a9ff-96b708934e08", 0, null, "b43d8366-91f4-466d-84a7-6d7b085e5ceb", "superuser@mail.com", true, "super", "adminuser", false, null, null, "SUPERUSER@MAIL.COM", "AQAAAAEAACcQAAAAEBwpOi8n3GSp5E1GQUAPK1JGnhaw45JSY8wkmSP/lEGhdW7TCl5fhR64rbW+LLjQ1w==", null, false, null, null, "1a6d30f8-67ac-4ebe-8327-4d6480ee593a", null, false, "superuser@mail.com", 10 });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "428f9f95-fd47-4b86-8850-e750f1f14154", "428f9f95-fd47-4b86-8850-e750f1f14154", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "60b2afea-f1a8-41fb-a384-c21cf943e323", "60b2afea-f1a8-41fb-a384-c21cf943e323", "Basic", "BASIC" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd3f901c-d282-40f1-9454-20000f0d44cc", "cd3f901c-d282-40f1-9454-20000f0d44cc", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed006433-adf4-4d85-b409-4ef0df916dea", "ed006433-adf4-4d85-b409-4ef0df916dea", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "428f9f95-fd47-4b86-8850-e750f1f14154", "faac366c-1420-4c88-a9ff-96b708934e08" });
        }
    }
}
