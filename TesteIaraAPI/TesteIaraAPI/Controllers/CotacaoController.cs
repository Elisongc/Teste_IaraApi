using Microsoft.AspNetCore.Mvc;
using TesteIaraAPI.Model.Entities;
using TesteIaraAPI.Repositories.Interfaces;

namespace TesteIaraAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CotacaoController :ControllerBase
    {
        private readonly ICotacaoRepository _cotacaoRepository;
        private readonly ICotacaoItemRepository _cotacaoItemRepository;

        public CotacaoController(ICotacaoRepository cotacaoRepository, ICotacaoItemRepository cotacaoItemRepository)
        {
            _cotacaoRepository = cotacaoRepository;
            _cotacaoItemRepository = cotacaoItemRepository;

        }

        [HttpGet]
        public async Task<IEnumerable<Cotacao>> GetCotacao()
        {
            return await _cotacaoRepository.Get();
        }

        [HttpGet("{NumeroCotacao}")]
        public async Task<ActionResult<Cotacao>> GetCotacao(int NumeroCotacao)
        {

            return await _cotacaoRepository.Get(NumeroCotacao);
        }

        [HttpPost]
        public async Task<ActionResult<Cotacao>> PostCotacao([FromBody] Cotacao Cotacao)
        {
            ValidacaoCotacaoController Validacao = new ValidacaoCotacaoController();
            string mensagem = Validacao.ValidacaoNovaCotacao(Cotacao);
            if (mensagem == "Sucesso")
            {
                var newCotacao = await _cotacaoRepository.Create(Cotacao);

                return CreatedAtAction(nameof(GetCotacao), new {NumeroCotacao = newCotacao.NumeroCotacao }, newCotacao);
            }
            else
            if( mensagem == "Sucesso |Endereço incompleto.") 
            {
                Cotacao cotacaoEndereco = Validacao.BuscaLogradouro(Cotacao);

                var newCotacao = await _cotacaoRepository.Create(cotacaoEndereco);
                return CreatedAtAction(nameof(GetCotacao), new { id = newCotacao.NumeroCotacao }, newCotacao);
            }
            else
            {
                return BadRequest(mensagem);
            }
        }

        [HttpDelete("{NumeroCotacao}")]
        public async Task<ActionResult> Delete(int NumeroCotacao)
        {
            var CotacaoToDelete = _cotacaoRepository.Get(NumeroCotacao);

            if (CotacaoToDelete == null)
            {
                return NotFound();

            }
            await _cotacaoRepository.Delete(NumeroCotacao);

            return NoContent();


        }

        [HttpPut]
        public async Task<ActionResult> PutCotacao(int NumeroCotacao, [FromBody] Cotacao Cotacao)
        {
            if (NumeroCotacao != Cotacao.NumeroCotacao)
            {
                return BadRequest();
            }
            await _cotacaoRepository.Update(Cotacao);

            return NoContent();
        }
    }
}
