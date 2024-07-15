using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

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
                values: new object[] { new Guid("ed7205d1-da02-49fa-b870-fc7df9688498"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ege@ege.com", new byte[] { 38, 27, 216, 136, 182, 28, 117, 1, 48, 214, 66, 62, 146, 94, 91, 237, 49, 206, 111, 93, 229, 241, 196, 14, 65, 75, 52, 16, 145, 131, 9, 142, 207, 130, 251, 85, 205, 44, 237, 141, 220, 106, 87, 178, 123, 113, 113, 172, 39, 176, 179, 100, 246, 247, 15, 26, 216, 118, 10, 148, 143, 2, 132, 52 }, new byte[] { 65, 1, 225, 34, 246, 127, 165, 209, 222, 43, 113, 9, 161, 187, 88, 126, 43, 239, 95, 5, 91, 98, 113, 38, 168, 144, 192, 232, 36, 44, 156, 67, 178, 154, 67, 31, 61, 24, 224, 5, 94, 220, 120, 140, 204, 81, 122, 227, 51, 78, 51, 14, 32, 134, 246, 40, 233, 137, 199, 181, 229, 191, 32, 113, 14, 119, 32, 55, 74, 213, 97, 235, 165, 159, 164, 80, 211, 131, 0, 237, 107, 73, 22, 35, 33, 242, 146, 33, 134, 177, 168, 169, 240, 148, 159, 4, 213, 56, 18, 102, 127, 110, 84, 19, 93, 53, 249, 105, 123, 39, 47, 229, 231, 59, 102, 80, 209, 102, 72, 78, 131, 99, 54, 110, 221, 163, 96, 35 }, null, "EgeUmut" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("9b29474f-44cc-4f7c-9b4f-bcbb6af6425c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("ed7205d1-da02-49fa-b870-fc7df9688498") });

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9b29474f-44cc-4f7c-9b4f-bcbb6af6425c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ed7205d1-da02-49fa-b870-fc7df9688498"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
