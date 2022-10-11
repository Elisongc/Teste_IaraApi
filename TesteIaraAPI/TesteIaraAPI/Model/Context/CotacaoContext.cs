using Microsoft.EntityFrameworkCore;
using TesteIaraAPI.Model.Entities;

namespace TesteIaraAPI.Model.Context
{
    public class CotacaoContext: DbContext
    {
        public CotacaoContext(DbContextOptions<CotacaoContext> options) : base(options)
        {
            Database.EnsureCreated();

        }

        public DbSet<Cotacao> Cotacaos { get; set; }
    }
}
