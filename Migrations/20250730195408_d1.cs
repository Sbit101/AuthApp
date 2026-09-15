using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class d1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MpoxCaseDBList",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameOfTreatingPhysician = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    NameOfHealthcareCentre = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    HealthcareCentreTelephone = table.Column<int>(type: "INTEGER", nullable: false),
                    PatientFirstName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PatientLastName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PatientAge = table.Column<int>(type: "INTEGER", nullable: false),
                    PatientSex = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PatientCountry = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PatientTelephoneNumber = table.Column<double>(type: "REAL", nullable: false),
                    PatientCity = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PatientAddress = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PatientHouseHoldSize = table.Column<int>(type: "INTEGER", nullable: false),
                    PatientSymptomsPositiveForMpox = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    DateofFirstClinicalDiagnosis = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateSymptomsOnset = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOnsetOfRash = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PatientRashPicture = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MpoxCaseDBList", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BackgroundStory", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureOne", "ProfilePicture", "SecurityStamp", "Specialties", "TwoFactorEnabled", "UserName", "UsernameChangeLimit" },
                values: new object[] { "2dbc5f2d-f620-43bd-96d0-cc3a1e0768aa", 0, null, "e221b43d-98db-4d21-a533-4769d7df2f64", "superuser@mail.com", true, "super", "adminuser", false, null, null, "SUPERUSER@MAIL.COM", "AQAAAAEAACcQAAAAEDOvic5I/3ekcr7kkzkzabuV1QMQ+gP0NRU0qpagPL5Pz+e4RrB0ZvzL+y8kvSzUkg==", null, false, null, null, "bd2f7bb7-7752-40ed-bbdd-9d4c220f3741", null, false, "superuser@mail.com", 10 });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "097fe517-2c35-4987-8f36-fcb9677aefe2", "097fe517-2c35-4987-8f36-fcb9677aefe2", "Basic", "BASIC" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5d59adeb-32c0-4aa6-ac8c-6b46a3144e43", "5d59adeb-32c0-4aa6-ac8c-6b46a3144e43", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b2f8cbc4-56ee-443d-bf25-488f081fc85e", "b2f8cbc4-56ee-443d-bf25-488f081fc85e", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "baa1e4c3-ad1c-4d41-b434-d9cf7399c1ad", "baa1e4c3-ad1c-4d41-b434-d9cf7399c1ad", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "baa1e4c3-ad1c-4d41-b434-d9cf7399c1ad", "2dbc5f2d-f620-43bd-96d0-cc3a1e0768aa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MpoxCaseDBList",
                schema: "Identity");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "097fe517-2c35-4987-8f36-fcb9677aefe2");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "5d59adeb-32c0-4aa6-ac8c-6b46a3144e43");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "b2f8cbc4-56ee-443d-bf25-488f081fc85e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "baa1e4c3-ad1c-4d41-b434-d9cf7399c1ad", "2dbc5f2d-f620-43bd-96d0-cc3a1e0768aa" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2dbc5f2d-f620-43bd-96d0-cc3a1e0768aa");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "baa1e4c3-ad1c-4d41-b434-d9cf7399c1ad");

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
    }
}
