using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace AmeriTrade.API
{
    public class AmeriTrade
    {
        /// <summary>
        /// Retorna a url  montada autenticação para logar na API AmeriTrade e recuperar o code
        /// </summary>
        /// <param name="autenticacao"></param>
        /// <returns></returns>
        public string retornarUrlAutenticacao(Authentication autenticacao)
        {
            return $"https://auth.tdameritrade.com/auth?response_type=code&redirect_uri={autenticacao.uri}%3A%2F%2F{autenticacao.host}%3A{autenticacao.port}&client_id={autenticacao.clientId}%40AMER.OAUTHAP";
        }

        /// <summary>
        /// Retorna o Token Bearer após a recuperação code
        /// </summary>
        /// <param name="code"></param>
        /// <param name="autenticacao"></param>
        /// <returns></returns>
        public ResponseAPI AutenticarUsuario(string code, Authentication autenticacao)
        {
            var urlEnvio = $"{autenticacao.uri}://{autenticacao.host}:{autenticacao.port}";

            string url = string.Format("https://api.tdameritrade.com/v1/oauth2/token");
            RestClient client = new RestClient(url);
            RestRequest postRequest = new RestRequest(Method.POST);
            postRequest.AddHeader("cache-control", "no-cache");
            postRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
            postRequest.AddParameter("application/x-www-form-urlencoded", $"grant_type=authorization_code&access_type=offline&code={code}&client_id={autenticacao.clientId}@AMER.OAUTHAP&redirect_uri={urlEnvio}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(postRequest);

            ResponseAPI respostaAPI = JsonConvert.DeserializeObject<ResponseAPI>(response.Content);


            return respostaAPI;
        }

        /// <summary>
        /// Account balances, positions, and orders for a specific account.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="fields"></param>
        /// <param name="Authorization"></param>
        /// <returns></returns>
        public dynamic GetAcount(int accountId, string fields, string Authorization)
        {
            var url = string.Format($"https://api.tdameritrade.com/v1/accounts/{accountId}?fields={fields}");

            RestClient client = new RestClient(url);
            RestRequest postRequest = new RestRequest(Method.GET);
            postRequest.AddHeader("cache-control", "no-cache");
            postRequest.AddHeader("content-type", "application/json");
            postRequest.AddHeader("Authorization", $"Bearer {Authorization}");
            IRestResponse response = client.Execute(postRequest);

            var resposta = JsonConvert.DeserializeObject<dynamic>(response.Content);

            return resposta;
        }

        /// <summary>
        /// Account balances, positions, and orders for all linked accounts.
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="Authorization"></param>
        /// <returns></returns>
        public object GetAccounts(string fields, string Authorization)
        {
            var url = string.Format($"https://api.tdameritrade.com/v1/accounts?fields={fields}");

            RestClient client = new RestClient(url);
            RestRequest postRequest = new RestRequest(Method.GET);
            postRequest.AddHeader("cache-control", "no-cache");
            postRequest.AddHeader("content-type", "application/json");
            postRequest.AddHeader("Authorization", $"Bearer {Authorization}");
            IRestResponse response = client.Execute(postRequest);

            var resposta = JsonConvert.DeserializeObject<object>(response.Content);

            return resposta;
            /*

            return resposta;
            */
        }
    }
}
