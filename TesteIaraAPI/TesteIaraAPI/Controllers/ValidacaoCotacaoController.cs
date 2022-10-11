using Microsoft.AspNetCore.Mvc;
using TesteIaraAPI.Model.Entities;
using TesteIaraAPI.Repositories.Interfaces;

namespace TesteIaraAPI.Controllers
{
    public class ValidacaoCotacaoController:ControllerBase
    {
        public string ValidacaoNovaCotacao(Cotacao cotacao)
        {
            string msg = "";
            if (cotacao.CNPJComprador is null|| cotacao.CNPJComprador == "")
                msg += " |Cnpj do Comprador não preenchido. ";

            if(cotacao.CNPJFornecedor is null || cotacao.CNPJFornecedor == "")
                msg += " |Cnpj do Fornecedor não preenchido. ";

            if( cotacao.DataCotacao == null)
                msg += " |Cnpj do Fornecedor não preenchido. ";
                
            if(cotacao.DataEntregaCotacao == null)
                msg += " |Cnpj do Fornecedor não preenchido. ";

            if(cotacao.NumeroCotacao == 0 )
                msg += " |Cnpj do Fornecedor não preenchido. ";
            if (cotacao.CEP == "" || cotacao.CEP == null)
                msg += " |CEP não preenchido.";

            if (msg == "")
            {
                msg = "Sucesso";
                if((cotacao.Bairro == null || cotacao.Bairro == null) || (cotacao.Logradouro == null || cotacao.Logradouro == null) || (cotacao.UF == null || cotacao.UF == null))
                {
                    msg += " |Endereço incompleto.";
                }
            }
            
            return msg;
        }

        public Cotacao BuscaLogradouro(Cotacao cotacao)
        {
            ApiResource api = new ApiResource();
            Address endereco = api.GetAdress(cotacao.CEP);

            cotacao.UF = endereco.UF;
            cotacao.Logradouro = endereco.Logradouro;
            cotacao.Complemento = endereco.Complemento;
            cotacao.Bairro = endereco.Bairro;
            cotacao.Cidade = endereco.Localidade;
            return cotacao;
        }


    }
}
