using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e87edf5f-5cc0-49e5-ad5b-32fd6484bad1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("80ebd7ba-a754-4553-a7a3-cdd6e4ef8833"));

            migrationBuilder.RenameColumn(
                name: "UserName1",
                table: "Users",
                newName: "Email");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("83f1fb8c-19e8-4566-872d-6006af695c27"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ege@ege.com", new byte[] { 19, 144, 213, 79, 7, 141, 165, 51, 239, 84, 174, 132, 40, 13, 109, 26, 164, 14, 62, 116, 172, 241, 243, 50, 204, 108, 65, 192, 9, 63, 55, 36, 244, 124, 29, 138, 182, 14, 68, 73, 244, 13, 241, 16, 173, 33, 94, 128, 170, 203, 64, 168, 143, 178, 143, 37, 202, 44, 202, 203, 61, 164, 226, 247 }, new byte[] { 3, 242, 126, 133, 106, 38, 110, 34, 9, 122, 19, 105, 23, 216, 81, 156, 107, 111, 62, 216, 211, 103, 252, 204, 66, 102, 139, 153, 244, 40, 188, 81, 208, 238, 169, 114, 100, 255, 244, 115, 172, 191, 204, 206, 139, 247, 197, 252, 100, 131, 22, 113, 131, 96, 126, 181, 87, 245, 21, 57, 61, 137, 86, 148, 34, 217, 116, 105, 88, 220, 93, 0, 227, 124, 140, 84, 93, 52, 144, 79, 241, 7, 210, 27, 77, 89, 0, 196, 163, 78, 162, 183, 193, 64, 12, 226, 60, 120, 184, 53, 149, 200, 13, 65, 247, 240, 217, 232, 82, 230, 165, 142, 152, 177, 102, 57, 19, 47, 164, 249, 202, 142, 85, 121, 79, 122, 122, 21 }, null, "EgeUmut" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a1fe8e3a-c79e-4404-9afe-af736dcac428"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("83f1fb8c-19e8-4566-872d-6006af695c27") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a1fe8e3a-c79e-4404-9afe-af736dcac428"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("83f1fb8c-19e8-4566-872d-6006af695c27"));

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "UserName1");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "UserName", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName1" },
                values: new object[] { new Guid("80ebd7ba-a754-4553-a7a3-cdd6e4ef8833"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ege@ege.com", new byte[] { 204, 99, 70, 249, 26, 155, 204, 36, 19, 146, 100, 192, 146, 90, 59, 83, 96, 100, 220, 251, 67, 171, 128, 54, 9, 106, 120, 247, 151, 116, 164, 196, 78, 104, 2, 86, 142, 175, 82, 170, 129, 234, 187, 87, 103, 120, 5, 226, 189, 178, 157, 249, 197, 46, 28, 101, 36, 248, 151, 132, 252, 124, 196, 133 }, new byte[] { 53, 130, 62, 240, 179, 70, 251, 163, 22, 191, 64, 227, 19, 43, 132, 169, 197, 243, 10, 87, 120, 39, 84, 9, 189, 75, 126, 247, 18, 145, 184, 204, 149, 216, 126, 74, 130, 162, 147, 165, 229, 102, 207, 39, 73, 15, 61, 155, 154, 156, 38, 165, 146, 202, 63, 4, 221, 23, 73, 126, 132, 219, 171, 105, 4, 74, 87, 171, 236, 47, 5, 7, 103, 41, 68, 213, 18, 219, 154, 208, 127, 59, 31, 105, 190, 167, 209, 145, 56, 57, 245, 149, 253, 164, 104, 67, 167, 144, 72, 130, 173, 222, 10, 86, 99, 209, 226, 181, 178, 23, 48, 250, 224, 63, 76, 84, 151, 126, 128, 48, 117, 72, 171, 171, 177, 148, 230, 153 }, null, "EgeUmut" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e87edf5f-5cc0-49e5-ad5b-32fd6484bad1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("80ebd7ba-a754-4553-a7a3-cdd6e4ef8833") });
        }
    }
}
