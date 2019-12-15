using BTCTrader.Entities;
using BTCTrader.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BTCTrader.Api
{
    public class ApiClient : IApiClient
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;
        private readonly string _privateKey;
        

        public ApiClient(AppSettings appSettings)
        {
            _baseUrl = appSettings.BaseUrl;
            _apiKey = appSettings.ApiKey;
            _privateKey = appSettings.PrivateKey;
            
        }

        public async Task<ResponseModel> Get(string path, string queryString)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                GenerateHeaders(client, "GET", null, path);

                var fullPath = !string.IsNullOrEmpty(queryString) ? path + "?" + queryString : path;

                var response = await client.GetAsync(fullPath);
                if (!response.IsSuccessStatusCode)
                    Console.WriteLine("Error: " + response.StatusCode.ToString());

                var content = await response.Content.ReadAsStringAsync();

                return new ResponseModel
                {
                    Headers = response.Headers,
                    Content = await response.Content.ReadAsStringAsync()
                };
            }
        }

        public async Task<string> Post(string path, string queryString, object data)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var stringifiedData = data != null ? JsonConvert.SerializeObject(data) : null;
                GenerateHeaders(client, "POST", stringifiedData, path);

                var fullPath = !string.IsNullOrEmpty(queryString) ? path + "?" + queryString : path;
                var content = new StringContent(stringifiedData, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(fullPath, content);
                if (!response.IsSuccessStatusCode)
                    Console.WriteLine("Error: " + response.StatusCode.ToString());

                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> Put(string path, string queryString, object data)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var stringifiedData = data != null ? JsonConvert.SerializeObject(data) : null;
                GenerateHeaders(client, "PUT", stringifiedData, path);

                var fullPath = !string.IsNullOrEmpty(queryString) ? path + "?" + queryString : path;
                var content = new StringContent(stringifiedData, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(fullPath, content);
                if (!response.IsSuccessStatusCode)
                    Console.WriteLine("Error: " + response.StatusCode.ToString());

                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> Delete(string path, string queryString)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                GenerateHeaders(client, "DELETE", null, path);

                var fullPath = !string.IsNullOrEmpty(queryString) ? path + "?" + queryString : path;

                var response = await client.DeleteAsync(fullPath);
                if (!response.IsSuccessStatusCode)
                    Console.WriteLine("Error: " + response.StatusCode.ToString());

                return await response.Content.ReadAsStringAsync();
            }
        }


        private void GenerateHeaders(HttpClient client, string method, string data, string path)
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var message = method + path + now.ToString();
            if (!string.IsNullOrEmpty(data))
                message += data;

            string signature = SignMessage(message);
            client.DefaultRequestHeaders.Add("Accept", "application /json");
            client.DefaultRequestHeaders.Add("Accept-Charset", "UTF-8");
            client.DefaultRequestHeaders.Add("BM-AUTH-APIKEY", _apiKey);
            client.DefaultRequestHeaders.Add("BM-AUTH-TIMESTAMP", now.ToString());
            client.DefaultRequestHeaders.Add("BM-AUTH-SIGNATURE", signature);
        }

        private string SignMessage(string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);

            using (var hash = new HMACSHA512(Convert.FromBase64String(_privateKey)))
            {
                var hashedInputeBytes = hash.ComputeHash(bytes);
                return Convert.ToBase64String(hashedInputeBytes);
            }
        }
    }
}
