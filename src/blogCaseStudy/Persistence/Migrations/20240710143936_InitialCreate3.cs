using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a1fe8e3a-c79e-4404-9afe-af736dcac428"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("83f1fb8c-19e8-4566-872d-6006af695c27"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("1686958d-309c-4d85-812c-fb4a6a5e4f01"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ege@ege.com", new byte[] { 156, 120, 188, 250, 137, 5, 57, 79, 167, 61, 216, 209, 249, 106, 231, 194, 173, 112, 186, 108, 177, 30, 203, 124, 190, 109, 183, 199, 213, 228, 120, 36, 15, 106, 6, 65, 221, 109, 31, 50, 89, 210, 13, 54, 11, 74, 113, 11, 199, 189, 192, 216, 113, 57, 189, 214, 40, 20, 113, 221, 211, 174, 75, 24 }, new byte[] { 156, 111, 18, 66, 151, 144, 246, 44, 246, 241, 241, 242, 205, 255, 115, 190, 205, 95, 128, 154, 215, 39, 113, 242, 250, 131, 94, 235, 118, 16, 101, 70, 136, 100, 5, 160, 246, 123, 165, 80, 41, 34, 157, 105, 189, 147, 15, 230, 117, 77, 197, 208, 179, 43, 32, 7, 63, 158, 28, 68, 200, 65, 227, 130, 248, 48, 181, 156, 139, 170, 85, 161, 106, 244, 13, 120, 179, 109, 192, 38, 82, 199, 182, 116, 37, 41, 103, 165, 113, 4, 68, 217, 242, 32, 244, 155, 196, 153, 74, 74, 14, 68, 172, 65, 244, 246, 139, 160, 59, 219, 107, 233, 76, 160, 155, 228, 56, 165, 225, 158, 168, 243, 165, 59, 116, 224, 14, 211 }, null, "EgeUmut" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("b31b3286-64d7-4fa4-a690-d529022e63da"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("1686958d-309c-4d85-812c-fb4a6a5e4f01") });

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("b31b3286-64d7-4fa4-a690-d529022e63da"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1686958d-309c-4d85-812c-fb4a6a5e4f01"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("83f1fb8c-19e8-4566-872d-6006af695c27"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ege@ege.com", new byte[] { 19, 144, 213, 79, 7, 141, 165, 51, 239, 84, 174, 132, 40, 13, 109, 26, 164, 14, 62, 116, 172, 241, 243, 50, 204, 108, 65, 192, 9, 63, 55, 36, 244, 124, 29, 138, 182, 14, 68, 73, 244, 13, 241, 16, 173, 33, 94, 128, 170, 203, 64, 168, 143, 178, 143, 37, 202, 44, 202, 203, 61, 164, 226, 247 }, new byte[] { 3, 242, 126, 133, 106, 38, 110, 34, 9, 122, 19, 105, 23, 216, 81, 156, 107, 111, 62, 216, 211, 103, 252, 204, 66, 102, 139, 153, 244, 40, 188, 81, 208, 238, 169, 114, 100, 255, 244, 115, 172, 191, 204, 206, 139, 247, 197, 252, 100, 131, 22, 113, 131, 96, 126, 181, 87, 245, 21, 57, 61, 137, 86, 148, 34, 217, 116, 105, 88, 220, 93, 0, 227, 124, 140, 84, 93, 52, 144, 79, 241, 7, 210, 27, 77, 89, 0, 196, 163, 78, 162, 183, 193, 64, 12, 226, 60, 120, 184, 53, 149, 200, 13, 65, 247, 240, 217, 232, 82, 230, 165, 142, 152, 177, 102, 57, 19, 47, 164, 249, 202, 142, 85, 121, 79, 122, 122, 21 }, null, "EgeUmut" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a1fe8e3a-c79e-4404-9afe-af736dcac428"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("83f1fb8c-19e8-4566-872d-6006af695c27") });

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
