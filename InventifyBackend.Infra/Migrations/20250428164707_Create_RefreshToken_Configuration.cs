using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventifyBackend.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Create_RefreshToken_Configuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("134193b1-1866-46d5-a286-3b25dfac0282"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2092fcaf-e61e-4723-b5b1-a243af816466"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2b619531-7eb6-45a4-99af-c219a1c73c85"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5fa39083-d4b2-4d36-ae92-c52a44638503"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7180a654-3075-46cd-ac73-956499d1f7f5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ae738327-f557-4309-b2ef-95a8901a2b62"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b4e1d5d6-1fc2-4016-b7fc-7c1631329a1c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e9748f94-9f60-4cf5-8834-f4df234af3b4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f6891beb-8e5b-4fa5-9bba-df51e976b016"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fae86d7c-eb52-46ad-8a1c-f21f6b36aeaa"));

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "RefreshTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RevokedByIp",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ReplacedByToken",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByIp",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "RefreshTokens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "ProductCategories", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("21726eb1-c243-4081-b862-08badd003f34"), new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6883), "Suprimentos e equipamentos de escritório", "Material de Escritório", null, new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6884) },
                    { new Guid("252be656-59f1-4890-937b-aa226adff07c"), new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6891), "Peças e acessórios para veículos", "Peças Automotivas", null, new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6891) },
                    { new Guid("27f5b0ea-7826-441b-9ca7-715993d4d0f0"), new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6886), "Produtos para limpeza doméstica e industrial", "Produtos de Limpeza", null, new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6886) },
                    { new Guid("2da11882-f833-49a0-a4ad-ed7542fb5ed4"), new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6858), "Móveis para escritório, casa e jardim", "Móveis", null, new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6859) },
                    { new Guid("3b8e60bc-e9f1-4989-af1b-eac74da8557b"), new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6866), "Produtos alimentícios não perecíveis", "Alimentos", null, new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6866) },
                    { new Guid("6112a428-ce92-4d29-a5b0-320f1f4a1279"), new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6881), "Ferramentas manuais e elétricas", "Ferramentas", null, new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6881) },
                    { new Guid("6765252a-a087-47f3-aabc-ff076889d1d9"), new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6888), "EPIs e equipamentos de segurança", "Equipamentos de Segurança", null, new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6889) },
                    { new Guid("6b5822ce-4af9-4348-9b21-a4c303a2e52d"), new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6841), "Produtos eletrônicos como computadores, smartphones, tablets, etc.", "Eletrônicos", null, new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6852) },
                    { new Guid("705aeb8d-d276-4fec-8da2-23ad17e7e72b"), new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6863), "Roupas, calçados e acessórios", "Vestuário", null, new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6864) },
                    { new Guid("b1772321-a941-46bb-8cf7-9abd74ec2697"), new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6868), "Bebidas alcoólicas e não alcoólicas", "Bebidas", null, new DateTime(2025, 4, 28, 13, 47, 6, 187, DateTimeKind.Local).AddTicks(6869) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Expires",
                table: "RefreshTokens",
                column: "Expires");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Token",
                table: "RefreshTokens",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId1",
                table: "RefreshTokens",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId1",
                table: "RefreshTokens",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId1",
                table: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_Expires",
                table: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_Token",
                table: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_UserId1",
                table: "RefreshTokens");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("21726eb1-c243-4081-b862-08badd003f34"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("252be656-59f1-4890-937b-aa226adff07c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("27f5b0ea-7826-441b-9ca7-715993d4d0f0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2da11882-f833-49a0-a4ad-ed7542fb5ed4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3b8e60bc-e9f1-4989-af1b-eac74da8557b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6112a428-ce92-4d29-a5b0-320f1f4a1279"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6765252a-a087-47f3-aabc-ff076889d1d9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6b5822ce-4af9-4348-9b21-a4c303a2e52d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("705aeb8d-d276-4fec-8da2-23ad17e7e72b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b1772321-a941-46bb-8cf7-9abd74ec2697"));

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "RefreshTokens");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "RevokedByIp",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReplacedByToken",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByIp",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "ProductCategories", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("134193b1-1866-46d5-a286-3b25dfac0282"), new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7521), "Produtos eletrônicos como computadores, smartphones, tablets, etc.", "Eletrônicos", null, new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7530) },
                    { new Guid("2092fcaf-e61e-4723-b5b1-a243af816466"), new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7562), "Produtos para limpeza doméstica e industrial", "Produtos de Limpeza", null, new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7563) },
                    { new Guid("2b619531-7eb6-45a4-99af-c219a1c73c85"), new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7539), "Roupas, calçados e acessórios", "Vestuário", null, new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7539) },
                    { new Guid("5fa39083-d4b2-4d36-ae92-c52a44638503"), new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7536), "Móveis para escritório, casa e jardim", "Móveis", null, new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7537) },
                    { new Guid("7180a654-3075-46cd-ac73-956499d1f7f5"), new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7567), "Peças e acessórios para veículos", "Peças Automotivas", null, new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7568) },
                    { new Guid("ae738327-f557-4309-b2ef-95a8901a2b62"), new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7565), "EPIs e equipamentos de segurança", "Equipamentos de Segurança", null, new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7565) },
                    { new Guid("b4e1d5d6-1fc2-4016-b7fc-7c1631329a1c"), new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7548), "Suprimentos e equipamentos de escritório", "Material de Escritório", null, new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7549) },
                    { new Guid("e9748f94-9f60-4cf5-8834-f4df234af3b4"), new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7543), "Bebidas alcoólicas e não alcoólicas", "Bebidas", null, new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7544) },
                    { new Guid("f6891beb-8e5b-4fa5-9bba-df51e976b016"), new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7541), "Produtos alimentícios não perecíveis", "Alimentos", null, new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7542) },
                    { new Guid("fae86d7c-eb52-46ad-8a1c-f21f6b36aeaa"), new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7546), "Ferramentas manuais e elétricas", "Ferramentas", null, new DateTime(2025, 4, 27, 13, 15, 44, 376, DateTimeKind.Local).AddTicks(7546) }
                });
        }
    }
}
