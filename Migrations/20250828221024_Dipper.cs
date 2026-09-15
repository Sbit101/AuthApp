using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class Dipper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "DiphtheriaDBList",
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
                    PatientSymptomsPositiveForDiphtheria = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    DateofFirstClinicalDiagnosis = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateSymptomsOnset = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PatientDiphtheriaPicture = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiphtheriaDBList", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiphtheriaDBList",
                schema: "Identity");

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
    }
}
