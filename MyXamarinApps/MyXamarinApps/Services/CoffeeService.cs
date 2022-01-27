using MyXamarinApps.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyXamarinApps.Services
{
    public class CoffeeService : ICoffee
    {
        private HttpClient _client;
        public CoffeeService()
        {
            _client = new HttpClient();
        }
        public async Task Add(Coffee coffee)
        {
            var uri = new Uri($"{Helpers.ServiceHelper.serviceUrl}/api/Coffee");
            try
            {
                var json = JsonConvert.SerializeObject(coffee);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Gagal menambahkan data coffee");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task Edit(int id, Coffee coffee)
        {
            var uri = new Uri($"{Helpers.ServiceHelper.serviceUrl}/api/Coffee/{id}");
            try
            {
                var json = JsonConvert.SerializeObject(coffee);
                var content = new StringContent(json,Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Gagal mengupdate data coffee");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Coffee>> GetAll()
        {
            List<Coffee> lstCofee = new List<Coffee>();
            var uri = new Uri($"{Helpers.ServiceHelper.serviceUrl}/api/Coffee");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    lstCofee = JsonConvert.DeserializeObject<List<Coffee>>(content);
                }
                return lstCofee;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Coffee> GetById(int id)
        {
            Coffee coffee = new Coffee();
            var uri = new Uri($"{Helpers.ServiceHelper.serviceUrl}/api/Coffee/{id}");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    coffee = JsonConvert.DeserializeObject<Coffee>(content);
                }
                return coffee;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task Remove(int id)
        {
            var uri = new Uri($"{Helpers.ServiceHelper.serviceUrl}/api/Coffee/{id}");
            try
            {
                var response = await _client.DeleteAsync(uri);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Gagal untuk delete data");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
