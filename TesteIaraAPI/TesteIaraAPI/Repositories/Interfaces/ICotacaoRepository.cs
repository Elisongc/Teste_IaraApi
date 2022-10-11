using TesteIaraAPI.Model.Entities;

namespace TesteIaraAPI.Repositories.Interfaces
{
    public interface ICotacaoRepository
    {
        Task<IEnumerable<Cotacao>> Get();

        Task<Cotacao> Get(int id);

        Task<Cotacao> Create(Cotacao Cotacao);

        Task Update(Cotacao Cotacao);
        Task Delete(int id);

    }
}
