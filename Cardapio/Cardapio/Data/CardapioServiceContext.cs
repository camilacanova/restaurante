using CardapioService.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CardapioService.Data
{
    public class CardapioServiceContext : DbContext
    {

        public DbSet<Cardapio> Cardapios { get; set; }
        public DbSet<Adicional> Adicionais { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ItemCardapio> ItensCardapio { get; set; }
        public DbSet<TipoAdicional> TiposAdicional { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }


        public CardapioServiceContext(DbContextOptions<CardapioServiceContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Cascade;
            }

            modelBuilder.Entity<Restaurante>().HasData(
                new Restaurante { Id = 1, Ativo = true, Nome = "Restaurante A", Observacao = "Teste" }
            );

            modelBuilder.Entity<Cardapio>().HasData(
              new Cardapio { Id = 1, Nome = "Café da manhã", Ativo = true, Observacao = "Teste" }
            );

            modelBuilder.Entity<ItemCardapio>().HasData(
              new ItemCardapio { Id = 1, NomeItem = "Ovos Mexidos", Ativo = true, CardapioId = 1, Observacao = "Teste", Valor = 10 },
              new ItemCardapio { Id = 2, NomeItem = "Café", Ativo = true, CardapioId = 1, Observacao = "Teste", Valor = 10 },
              new ItemCardapio { Id = 3, NomeItem = "Bolo de milho", Ativo = true, CardapioId = 1, Observacao = "Teste", Valor = 10 },
              new ItemCardapio { Id = 4, NomeItem = "Baguete", Ativo = true, CardapioId = 1, Observacao = "Teste", Valor = 10 }
            );


        }
    }
}
