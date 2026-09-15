using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class xxyyme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MeaslesDBList",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameOfTreatingPhysician = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    NameOfHealthcareCentre = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    HealthcareCentreTelephone = table.Column<double>(type: "REAL", nullable: false),
                    PatientFirstName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PatientLastName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PatientAge = table.Column<int>(type: "INTEGER", nullable: false),
                    PatientSex = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PatientCountry = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PatientTelephoneNumber = table.Column<double>(type: "REAL", nullable: false),
                    PatientCity = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PatientAddress = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PatientHouseHoldSize = table.Column<int>(type: "INTEGER", nullable: false),
                    PatientSymptomsPositiveForMeasles = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    DateofFirstClinicalDiagnosis = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateSymptomsOnset = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PatientMeaslesPicture = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeaslesDBList", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BackgroundStory", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureOne", "ProfilePicture", "SecurityStamp", "Specialties", "TwoFactorEnabled", "UserName", "UsernameChangeLimit" },
                values: new object[] { "ca8f1755-1ae3-4c68-aaa5-1896a98b0e52", 0, null, "0ac33d9d-82d2-43c4-aee4-718152d65c44", "superuser@mail.com", true, "super", "adminuser", false, null, null, "SUPERUSER@MAIL.COM", "AQAAAAEAACcQAAAAEKNdMUC7ZoeUrTy8rw2DLXU3pRzqG2fPEtnaI0XS9sZk1PYSGW/tM/fejhsWj3BcSQ==", null, false, null, null, "bb967b6b-7b55-497a-87d3-5ed262cb330b", null, false, "superuser@mail.com", 10 });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2278a634-aa52-473a-89ce-416f359a06bc", "2278a634-aa52-473a-89ce-416f359a06bc", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "756c9c1e-ffb5-4e70-aed6-3fe0f3a42475", "756c9c1e-ffb5-4e70-aed6-3fe0f3a42475", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "863f4bb6-f47e-4734-9f48-99183075d2ac", "863f4bb6-f47e-4734-9f48-99183075d2ac", "Basic", "BASIC" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d7dac39b-268a-4a8d-a43d-aaa1d29c6a68", "d7dac39b-268a-4a8d-a43d-aaa1d29c6a68", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "756c9c1e-ffb5-4e70-aed6-3fe0f3a42475", "ca8f1755-1ae3-4c68-aaa5-1896a98b0e52" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeaslesDBList",
                schema: "Identity");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "2278a634-aa52-473a-89ce-416f359a06bc");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "863f4bb6-f47e-4734-9f48-99183075d2ac");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "d7dac39b-268a-4a8d-a43d-aaa1d29c6a68");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "756c9c1e-ffb5-4e70-aed6-3fe0f3a42475", "ca8f1755-1ae3-4c68-aaa5-1896a98b0e52" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca8f1755-1ae3-4c68-aaa5-1896a98b0e52");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "756c9c1e-ffb5-4e70-aed6-3fe0f3a42475");

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
    }
}
