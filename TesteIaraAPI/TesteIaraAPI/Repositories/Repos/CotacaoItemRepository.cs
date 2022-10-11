using Microsoft.EntityFrameworkCore;
using TesteIaraAPI.Model.Context;
using TesteIaraAPI.Model.Entities;
using TesteIaraAPI.Repositories.Interfaces;

namespace TesteIaraAPI.Repositories.Repos
{
    public class CotacaoItemRepository : ICotacaoItemRepository
    {

        private readonly CotacaoItemContext _context;
        public CotacaoItemRepository(CotacaoItemContext context)
        {
            _context = context;

        }

        async Task<CotacaoItem> ICotacaoItemRepository.Create(CotacaoItem CotacaoItem)
        {
            _context.CotacaoItems.Add(CotacaoItem);

            await _context.SaveChangesAsync();

            return CotacaoItem;

        }

        async Task ICotacaoItemRepository.Delete(int id)
        {
            var CotacaoItemToDelete = await _context.CotacaoItems.FindAsync(id);
            _context.CotacaoItems.Remove(CotacaoItemToDelete);
            await _context.SaveChangesAsync();


        }

        async Task<IEnumerable<CotacaoItem>> ICotacaoItemRepository.Get()
        {
            return await _context.CotacaoItems.ToListAsync();
        }

        async Task<CotacaoItem> ICotacaoItemRepository.Get(int id)
        {
            return await _context.CotacaoItems.FindAsync(id);
        }

        async Task ICotacaoItemRepository.Update(CotacaoItem CotacaoItem)
        {
            _context.Entry(CotacaoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
