using CoreProject.UI.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using CoreProject.Entity.Abstract;
using CoreProject.Entity.Concrete;
using System.Text;

namespace CoreProject.UI.ApiProvider
{
    public static class GetListProvider<Tentity> where Tentity : class
    {
       
        [HttpGet]
        public static async Task<List<Tentity>> GetListAsync(string controller,string method)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/{controller}{"/"}{method}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Tentity>>(jsonString);
                return values;
            }
            return null;
        }

        
    }
}

