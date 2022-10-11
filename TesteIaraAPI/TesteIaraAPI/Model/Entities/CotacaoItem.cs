namespace TesteIaraAPI.Model.Entities
{
    public class CotacaoItem
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int NumeroItem { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Marca { get; set; }
        public string Unidade { get; set; }

    }
}