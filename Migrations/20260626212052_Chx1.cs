using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApp.Migrations
{
    public partial class Chx1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ChikungunyaDBList",
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
                    PatientSymptomsPositiveForChikungunya = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    DateofFirstClinicalDiagnosis = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateSymptomsOnset = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOnsetOfRash = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PatientRashPicture = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChikungunyaDBList", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BackgroundStory", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureOne", "ProfilePicture", "SecurityStamp", "Specialties", "TwoFactorEnabled", "UserName", "UsernameChangeLimit" },
                values: new object[] { "833e51e9-5b4e-4733-bebd-c088abde96ac", 0, null, "466accfd-ba7b-49d6-8407-38113a88288a", "superuser@mail.com", true, "super", "adminuser", false, null, null, "SUPERUSER@MAIL.COM", "AQAAAAEAACcQAAAAEDcmhVqzFZQ9QCvQXvt4fZZSyR7iGEQfaBEW7Tc88pdThjjYyx2g610XBi0p6zqfOQ==", null, false, null, null, "01a3304e-8cbc-469b-b582-dde99eab6db9", null, false, "superuser@mail.com", 10 });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0bf08ffc-f1f2-4ec1-b013-d814bb49b076", "0bf08ffc-f1f2-4ec1-b013-d814bb49b076", "Moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44025f2d-4036-449b-8821-fa273e6c1622", "44025f2d-4036-449b-8821-fa273e6c1622", "Basic", "BASIC" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "639bd848-9641-41b9-9f07-a9a5335393f6", "639bd848-9641-41b9-9f07-a9a5335393f6", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97420140-f963-430f-b5a7-7fd22914ead8", "97420140-f963-430f-b5a7-7fd22914ead8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "639bd848-9641-41b9-9f07-a9a5335393f6", "833e51e9-5b4e-4733-bebd-c088abde96ac" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChikungunyaDBList",
                schema: "Identity");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "0bf08ffc-f1f2-4ec1-b013-d814bb49b076");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "44025f2d-4036-449b-8821-fa273e6c1622");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "97420140-f963-430f-b5a7-7fd22914ead8");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "639bd848-9641-41b9-9f07-a9a5335393f6", "833e51e9-5b4e-4733-bebd-c088abde96ac" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "833e51e9-5b4e-4733-bebd-c088abde96ac");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "639bd848-9641-41b9-9f07-a9a5335393f6");

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
    }
}
