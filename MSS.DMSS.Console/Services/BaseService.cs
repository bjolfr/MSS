using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MSS.DMSS.Console.Services
{
    public class BaseService
    {
        private HttpClient _client;
        public string BaseAddress => ConfigurationManager.AppSettings.Get("BaseAddress");
        public string FullAddress => BaseAddress + ConfigurationManager.AppSettings.Get("RelativeAddress");

        public BaseService()
        {
            _client = new HttpClient();
            //_client = new HttpClient(new DecompressionHandler());
            _client.BaseAddress = new Uri(FullAddress);
        }

        public async Task<string> GetStringAsync(string address)
        {
            return await _client.GetStringAsync(address);
        }

        public async Task<T> PostAsync<T>(string uri, object param)
        {
            T result = default(T);
            var response = await _client.PostAsJsonAsync(uri, param);
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<T>();
            return result;
        }
    }
}
