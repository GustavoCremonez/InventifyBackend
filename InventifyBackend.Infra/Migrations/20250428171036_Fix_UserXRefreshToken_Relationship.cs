using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventifyBackend.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Fix_UserXRefreshToken_Relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId1",
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "ProductCategories", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("41397ae6-07d9-4ac6-b39a-ddd586ef0a9d"), new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5826), "Suprimentos e equipamentos de escritório", "Material de Escritório", null, new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5827) },
                    { new Guid("4df46148-3847-4f2f-966b-7c483ce84047"), new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5804), "Produtos alimentícios não perecíveis", "Alimentos", null, new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5804) },
                    { new Guid("58bb4420-666a-4002-9154-33cf3762ef28"), new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5824), "Ferramentas manuais e elétricas", "Ferramentas", null, new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5824) },
                    { new Guid("5fd67f98-982a-48a3-8ed1-d8e42720a80b"), new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5801), "Roupas, calçados e acessórios", "Vestuário", null, new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5802) },
                    { new Guid("7cb404a4-003a-43fb-834a-436a1374dc1a"), new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5781), "Produtos eletrônicos como computadores, smartphones, tablets, etc.", "Eletrônicos", null, new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5792) },
                    { new Guid("91c48422-e5b3-4611-a4cd-9849977e4044"), new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5806), "Bebidas alcoólicas e não alcoólicas", "Bebidas", null, new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5807) },
                    { new Guid("975eca34-19b4-4c70-a1a9-5d4bcafe8848"), new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5831), "EPIs e equipamentos de segurança", "Equipamentos de Segurança", null, new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5832) },
                    { new Guid("9b4e4558-132e-459c-839b-38484aeee76d"), new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5833), "Peças e acessórios para veículos", "Peças Automotivas", null, new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5834) },
                    { new Guid("ddbc68e7-b0ff-49ab-968f-8233e6417f92"), new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5829), "Produtos para limpeza doméstica e industrial", "Produtos de Limpeza", null, new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5829) },
                    { new Guid("edf14e1d-ce7d-43ef-8dd6-6ae99840c664"), new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5799), "Móveis para escritório, casa e jardim", "Móveis", null, new DateTime(2025, 4, 28, 14, 10, 35, 99, DateTimeKind.Local).AddTicks(5800) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("41397ae6-07d9-4ac6-b39a-ddd586ef0a9d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4df46148-3847-4f2f-966b-7c483ce84047"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("58bb4420-666a-4002-9154-33cf3762ef28"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5fd67f98-982a-48a3-8ed1-d8e42720a80b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7cb404a4-003a-43fb-834a-436a1374dc1a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("91c48422-e5b3-4611-a4cd-9849977e4044"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("975eca34-19b4-4c70-a1a9-5d4bcafe8848"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9b4e4558-132e-459c-839b-38484aeee76d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ddbc68e7-b0ff-49ab-968f-8233e6417f92"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("edf14e1d-ce7d-43ef-8dd6-6ae99840c664"));

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
    }
}
