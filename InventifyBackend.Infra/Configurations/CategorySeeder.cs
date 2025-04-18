using InventifyBackend.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace InventifyBackend.Infra.Configurations;

public static class CategorySeeder
{
    public static void SeedCategories(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category(
                Guid.NewGuid(),
                "Eletrônicos",
                "Produtos eletrônicos como computadores, smartphones, tablets, etc.",
                DateTime.Now,
                DateTime.Now
            ),
            new Category(
                Guid.NewGuid(),
                "Móveis",
                "Móveis para escritório, casa e jardim",
                DateTime.Now,
                DateTime.Now
            ),
            new Category(
                Guid.NewGuid(),
                "Vestuário",
                "Roupas, calçados e acessórios",
                DateTime.Now,
                DateTime.Now
            ),
            new Category(
                Guid.NewGuid(),
                "Alimentos",
                "Produtos alimentícios não perecíveis",
                DateTime.Now,
                DateTime.Now
            ),
            new Category(
                Guid.NewGuid(),
                "Bebidas",
                "Bebidas alcoólicas e não alcoólicas",
                DateTime.Now,
                DateTime.Now
            ),
            new Category(
                Guid.NewGuid(),
                "Ferramentas",
                "Ferramentas manuais e elétricas",
                DateTime.Now,
                DateTime.Now
            ),
            new Category(
                Guid.NewGuid(),
                "Material de Escritório",
                "Suprimentos e equipamentos de escritório",
                DateTime.Now,
                DateTime.Now
            ),
            new Category(
                Guid.NewGuid(),
                "Produtos de Limpeza",
                "Produtos para limpeza doméstica e industrial",
                DateTime.Now,
                DateTime.Now
            ),
            new Category(
                Guid.NewGuid(),
                "Equipamentos de Segurança",
                "EPIs e equipamentos de segurança",
                DateTime.Now,
                DateTime.Now
            ),
            new Category(
                Guid.NewGuid(),
                "Peças Automotivas",
                "Peças e acessórios para veículos",
                DateTime.Now,
                DateTime.Now
            )
        );
    }
}