using Microsoft.EntityFrameworkCore;
using TesteIaraAPI.Model.Context;
using TesteIaraAPI.Model.Entities;
using TesteIaraAPI.Repositories.Interfaces;

namespace TesteIaraAPI.Repositories.Repos
{
    public class CotacaoRepository : ICotacaoRepository
    {
        private readonly CotacaoContext _context;
        public CotacaoRepository(CotacaoContext context)
        {
            _context = context;

        }

        async Task<Cotacao> ICotacaoRepository.Create(Cotacao Cotacao)
        {
            _context.Cotacaos.Add(Cotacao);

            await _context.SaveChangesAsync();
            
            return Cotacao;
            
        }

        async Task ICotacaoRepository.Delete(int id)
        {
            var CotacaoToDelete = await _context.Cotacaos.FindAsync(id);
            _context.Cotacaos.Remove(CotacaoToDelete);
            await _context.SaveChangesAsync();


        }

        async Task<IEnumerable<Cotacao>> ICotacaoRepository.Get()
        {
            return await _context.Cotacaos.ToListAsync();
        }

        async Task<Cotacao> ICotacaoRepository.Get(int id)
        {
            return await _context.Cotacaos.FindAsync(id);
    }

        async Task ICotacaoRepository.Update(Cotacao Cotacao)
        {
            _context.Entry(Cotacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
