using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Strategies
{
    public interface IGetProdutoStrategy : ITypeStrategy<Produto>
    {
    }
    public class GetProdutoStrategy : IGetProdutoStrategy
    {
        public Result<Produto> execute(Produto entity)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetAsync(string.Format("https://localhost:44308/api/cardapio/{0}/item_cardapio/{1}", entity.CardapioId, entity.Id)).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;

                        // by calling .Result you are synchronously reading the result
                        string responseString = responseContent.ReadAsStringAsync().Result;

                        var options = new JsonSerializerOptions (){
                            PropertyNameCaseInsensitive = true
                        };
                        
                        var produto = JsonSerializer.Deserialize<Produto>(responseString, options);

                        return new Result<Produto>() { Entities = new List<Produto>() { produto }, Success = true };
                    }
                    else
                        return new Result<Produto>() { Success = false, Messages = new List<string>() { "Erro ao consultar no serviço de Cardápio" } };
                }
                catch (System.Exception ex)
                {
                    return new Result<Produto>() { Success = false, Messages = new List<string>() { "Erro ao consultar no serviço de Cardápio" + ex.Message } };
                }
            }

        }
    }
}
