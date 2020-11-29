using CardapioService.Model;
using Microsoft.EntityFrameworkCore;

namespace CardapioService.Data
{
    public class CardapioServiceContext : DbContext
    {

        public DbSet<Cardapio> Cardapios { get; set; }

        public CardapioServiceContext(DbContextOptions<CardapioServiceContext> options) : base(options)
        {

        }
    }
}
