using Newtonsoft.Json;
using RestSharp;
using TesteIaraAPI.Model.Entities;

namespace TesteIaraAPI.Controllers
{
    public class ApiResource
    {
        public Address GetAdress(string CEP)
        {
            RestClient client = new RestClient($"https://viacep.com.br/");
            RestRequest request = new RestRequest($"ws/"+CEP+" /json/?callback=?", Method.Get);

            var response =   client.Execute<Address>(request);
            Address endereco = JsonConvert.DeserializeObject<Address>(response.Content.ToString());

            return endereco;
        }
    }
}
