namespace TesteIaraAPI.Model.Entities
{
    public class Cotacao
    {
        public int NumeroCotacao { get; set; } 
        public string? CNPJComprador { get; set; }
        public string? CNPJFornecedor { get; set; }
        public DateTime? DataCotacao { get; set; }
        public DateTime? DataEntregaCotacao { get; set; }
        public string? CEP { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }
        public string? Observacao { get; set; }
        public CotacaoItem[] CotacaoItens { get; set; }
    }
}
