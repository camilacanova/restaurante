using CardapioService.Model;
using Microsoft.EntityFrameworkCore;

namespace CardapioService.Data
{
    public class CardapioServiceContext : DbContext
    {

        public DbSet<Cardapio> Cardapios { get; set; }
        public DbSet<Adicional> Adicionais { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ItemCardapio> ItensCardapio { get; set; }
        public DbSet<TipoAdicional> TipoAdicionals { get; set; }


        public CardapioServiceContext(DbContextOptions<CardapioServiceContext> options) : base(options)
        {

        }
    }
}
