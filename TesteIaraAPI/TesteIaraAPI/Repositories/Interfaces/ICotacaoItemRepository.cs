using TesteIaraAPI.Model.Entities;

namespace TesteIaraAPI.Repositories.Interfaces
{
    public interface ICotacaoItemRepository
    {
        Task<IEnumerable<CotacaoItem>> Get();

        Task<CotacaoItem> Get(int id);

        Task<CotacaoItem> Create(CotacaoItem CotacaoItem);

        Task Update(CotacaoItem CotacaoItem);
        Task Delete(int id);
    }
}
