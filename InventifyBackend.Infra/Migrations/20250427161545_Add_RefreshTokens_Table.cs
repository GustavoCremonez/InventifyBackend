using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventifyBackend.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Add_RefreshTokens_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0afa587d-314d-4ab4-aa5d-b5caaebfd600"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("29a89cf0-484e-48cc-acf4-c5cff596fe81"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5481c2c7-5c1a-4ad6-959d-63ca04759e68"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7e549120-e202-488f-ac57-a32a977cfd84"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8aefbf51-6e4a-493b-b958-8f3128a9d684"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8baf5147-f65f-46d2-bf76-1dc38b709cc9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a64c92a0-890f-4d15-ad48-4d856730febd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ab0968a5-f181-41b1-b6d4-6ebc2bab46d7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e2463003-cef7-4836-bc87-483c6498d684"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e978a1e5-cec9-40ee-8567-a7f09c7b704b"));

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "ProductCategories", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0afa587d-314d-4ab4-aa5d-b5caaebfd600"), new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7296), "Suprimentos e equipamentos de escritório", "Material de Escritório", null, new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7296) },
                    { new Guid("29a89cf0-484e-48cc-acf4-c5cff596fe81"), new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7293), "Bebidas alcoólicas e não alcoólicas", "Bebidas", null, new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7293) },
                    { new Guid("5481c2c7-5c1a-4ad6-959d-63ca04759e68"), new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7297), "Produtos para limpeza doméstica e industrial", "Produtos de Limpeza", null, new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7298) },
                    { new Guid("7e549120-e202-488f-ac57-a32a977cfd84"), new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7289), "Roupas, calçados e acessórios", "Vestuário", null, new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7290) },
                    { new Guid("8aefbf51-6e4a-493b-b958-8f3128a9d684"), new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7248), "Produtos eletrônicos como computadores, smartphones, tablets, etc.", "Eletrônicos", null, new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7263) },
                    { new Guid("8baf5147-f65f-46d2-bf76-1dc38b709cc9"), new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7273), "Móveis para escritório, casa e jardim", "Móveis", null, new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7273) },
                    { new Guid("a64c92a0-890f-4d15-ad48-4d856730febd"), new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7294), "Ferramentas manuais e elétricas", "Ferramentas", null, new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7295) },
                    { new Guid("ab0968a5-f181-41b1-b6d4-6ebc2bab46d7"), new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7301), "Peças e acessórios para veículos", "Peças Automotivas", null, new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7301) },
                    { new Guid("e2463003-cef7-4836-bc87-483c6498d684"), new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7291), "Produtos alimentícios não perecíveis", "Alimentos", null, new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7292) },
                    { new Guid("e978a1e5-cec9-40ee-8567-a7f09c7b704b"), new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7299), "EPIs e equipamentos de segurança", "Equipamentos de Segurança", null, new DateTime(2025, 4, 19, 7, 6, 33, 121, DateTimeKind.Local).AddTicks(7300) }
                });
        }
    }
}
