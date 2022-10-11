using Microsoft.EntityFrameworkCore;
using TesteIaraAPI.Model.Entities;

namespace TesteIaraAPI.Model.Context
{
    public class CotacaoItemContext:DbContext
    {
        public CotacaoItemContext(DbContextOptions<CotacaoItemContext> options) : base(options)
        {
            Database.EnsureCreated();

        }

        public DbSet<CotacaoItem> CotacaoItems { get; set; }
    }
}
