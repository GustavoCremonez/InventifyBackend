using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventifyBackend.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FixProductsCategoriesMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("36ad6879-67cd-4d31-b9d4-774fe062450d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3fabf9d2-7205-46a7-ab0c-192afa83917e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4fe085ff-3165-4253-b37f-648fa56d3c60"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("76eb4cc0-4cc8-42ef-84e7-af5e0e960639"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("91568401-81f4-49e3-9cb9-47ae5773725c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aa48b776-5071-4878-9296-3f5eedc9b201"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b02b42d0-7fa7-4efc-a0d1-f74e1546db83"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cc931203-59b2-4738-a340-f0e1b3ca551d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d76f1c94-9e33-41c8-9e26-9b3595817a49"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ff9bbf22-8f32-40f0-9cfe-5897198feecf"));

            migrationBuilder.DropColumn(
                name: "ProductCategories",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "ProductCategories", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("21caeafa-4ce2-437d-854f-5621d483fae2"), new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1530), "Produtos alimentícios não perecíveis", "Alimentos", null, new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1530) },
                    { new Guid("297981b4-a69b-4a83-b7d0-3e0e4e0dc103"), new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1540), "Produtos para limpeza doméstica e industrial", "Produtos de Limpeza", null, new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1540) },
                    { new Guid("3261ae71-fdd9-4a9c-b32a-c209434dc1a1"), new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1533), "Bebidas alcoólicas e não alcoólicas", "Bebidas", null, new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1533) },
                    { new Guid("4d8c72bc-826b-4da3-8ddf-eddbd12c3d65"), new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1516), "Móveis para escritório, casa e jardim", "Móveis", null, new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1516) },
                    { new Guid("9027bbe9-f797-498d-991b-b7d30b2f37d2"), new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1518), "Roupas, calçados e acessórios", "Vestuário", null, new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1519) },
                    { new Guid("acbe9826-4301-471c-8c1e-72a6c1df19df"), new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1495), "Produtos eletrônicos como computadores, smartphones, tablets, etc.", "Eletrônicos", null, new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1509) },
                    { new Guid("c3c9b648-796a-4217-bb79-2f61b313efe4"), new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1542), "EPIs e equipamentos de segurança", "Equipamentos de Segurança", null, new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1543) },
                    { new Guid("d8274e02-1580-4a28-b72d-2d64496b9137"), new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1535), "Ferramentas manuais e elétricas", "Ferramentas", null, new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1536) },
                    { new Guid("dcefb848-6673-4037-afb8-241ea7e382ff"), new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1538), "Suprimentos e equipamentos de escritório", "Material de Escritório", null, new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1538) },
                    { new Guid("e485adf9-52bd-4940-8161-dd85db69da0d"), new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1545), "Peças e acessórios para veículos", "Peças Automotivas", null, new DateTime(2025, 4, 18, 18, 18, 53, 231, DateTimeKind.Local).AddTicks(1545) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("21caeafa-4ce2-437d-854f-5621d483fae2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("297981b4-a69b-4a83-b7d0-3e0e4e0dc103"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3261ae71-fdd9-4a9c-b32a-c209434dc1a1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4d8c72bc-826b-4da3-8ddf-eddbd12c3d65"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9027bbe9-f797-498d-991b-b7d30b2f37d2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("acbe9826-4301-471c-8c1e-72a6c1df19df"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c3c9b648-796a-4217-bb79-2f61b313efe4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d8274e02-1580-4a28-b72d-2d64496b9137"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dcefb848-6673-4037-afb8-241ea7e382ff"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e485adf9-52bd-4940-8161-dd85db69da0d"));

            migrationBuilder.AddColumn<string>(
                name: "ProductCategories",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "ProductCategories", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("36ad6879-67cd-4d31-b9d4-774fe062450d"), new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5087), "Roupas, calçados e acessórios", "Vestuário", null, new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5088) },
                    { new Guid("3fabf9d2-7205-46a7-ab0c-192afa83917e"), new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5107), "Suprimentos e equipamentos de escritório", "Material de Escritório", null, new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5108) },
                    { new Guid("4fe085ff-3165-4253-b37f-648fa56d3c60"), new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5115), "Peças e acessórios para veículos", "Peças Automotivas", null, new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5115) },
                    { new Guid("76eb4cc0-4cc8-42ef-84e7-af5e0e960639"), new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5085), "Móveis para escritório, casa e jardim", "Móveis", null, new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5085) },
                    { new Guid("91568401-81f4-49e3-9cb9-47ae5773725c"), new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5094), "Ferramentas manuais e elétricas", "Ferramentas", null, new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5095) },
                    { new Guid("aa48b776-5071-4878-9296-3f5eedc9b201"), new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5092), "Bebidas alcoólicas e não alcoólicas", "Bebidas", null, new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5092) },
                    { new Guid("b02b42d0-7fa7-4efc-a0d1-f74e1546db83"), new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5090), "Produtos alimentícios não perecíveis", "Alimentos", null, new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5090) },
                    { new Guid("cc931203-59b2-4738-a340-f0e1b3ca551d"), new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5112), "EPIs e equipamentos de segurança", "Equipamentos de Segurança", null, new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5113) },
                    { new Guid("d76f1c94-9e33-41c8-9e26-9b3595817a49"), new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5110), "Produtos para limpeza doméstica e industrial", "Produtos de Limpeza", null, new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5110) },
                    { new Guid("ff9bbf22-8f32-40f0-9cfe-5897198feecf"), new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5067), "Produtos eletrônicos como computadores, smartphones, tablets, etc.", "Eletrônicos", null, new DateTime(2025, 4, 18, 18, 8, 8, 808, DateTimeKind.Local).AddTicks(5078) }
                });
        }
    }
}
