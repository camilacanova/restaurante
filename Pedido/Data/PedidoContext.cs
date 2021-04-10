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

            modelBuilder.Entity<StatusItem>().HasData(
                new StatusItem() { Ativo = true, Descricao = "Solicitado", Id = 1 },
                new StatusItem() { Ativo = true, Descricao = "Em Preparação", Id = 2 },
                new StatusItem() { Ativo = true, Descricao = "Pronto", Id = 3 },
                new StatusItem() { Ativo = true, Descricao = "Entregue", Id = 4 }
            );

            modelBuilder.Entity<StatusPedido>().HasData(
                new StatusPedido() { Descricao = "Aberto", Id = 1, Ativo = true },
                new StatusPedido() { Descricao = "Encerrado", Id = 2, Ativo = true },
                new StatusPedido() { Descricao = "Pago", Id = 3, Ativo = true }
            );

            modelBuilder.Entity<TipoPagamento>().HasData(
                new TipoPagamento() { Descricao = "Cartão", Id = 1, Ativo = true },
                new TipoPagamento() { Descricao = "Dinheiro", Id = 2, Ativo = true }
            );
            
        }
    }
}
