using PedidoAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PedidoAPI.Data
{
    public class PedidoContext : DbContext
    {

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<StatusItem> StatusesItem { get; set; }
        public DbSet<StatusPedido> StatusesPedido { get; set; }
        public DbSet<TipoPagamento> TiposPagamento { get; set; }


        public PedidoContext(DbContextOptions<PedidoContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Cascade;
            }

            // modelBuilder.Entity<Restaurante>().HasData(
            //     new Restaurante { Id = 1, Ativo = true, Nome = "Restaurante A", Observacao = "Teste" }
            // );

            // modelBuilder.Entity<Cardapio>().HasData(
            //   new Cardapio { Id = 1, Nome = "Café da manhã", Ativo = true, Observacao = "Teste" }
            // );

            // modelBuilder.Entity<ItemCardapio>().HasData(
            //   new ItemCardapio { Id = 1, NomeItem = "Ovos Mexidos", Ativo = true, CardapioId = 1, Observacao = "Teste", Valor = 10 },
            //   new ItemCardapio { Id = 2, NomeItem = "Café", Ativo = true, CardapioId = 1, Observacao = "Teste", Valor = 10 },
            //   new ItemCardapio { Id = 3, NomeItem = "Bolo de milho", Ativo = true, CardapioId = 1, Observacao = "Teste", Valor = 10 },
            //   new ItemCardapio { Id = 4, NomeItem = "Baguete", Ativo = true, CardapioId = 1, Observacao = "Teste", Valor = 10 }
            // );


        }
    }
}
