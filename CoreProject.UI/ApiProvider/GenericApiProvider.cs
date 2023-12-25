using CoreProject.Entity.Concrete;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text;

namespace CoreProject.UI.ApiProvider
{
    public static class GenericApiProvider<Tentity> /*where Tentity : class*/
    {
        [HttpGet]
        public static async Task<List<Tentity>> GetListAsync(string controller, string method)
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

        [HttpPost]
        public static async Task<bool> AddTentityAsync(string controller, string method, Tentity tentity)
        {
            var httpClient = new HttpClient();
            var jsonBlog = JsonConvert.SerializeObject(tentity);
            StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync($"https://localhost:7111/api/{controller}{"/"}{method}",
             content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static async Task<bool> DeleteTentityAsync(string controller,int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync($"https://localhost:7111/api/{controller}{"/"}{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        public static async Task<Tentity?> GetByIdTentityAsync(string? controller,string? method,int? id)
        {
            var httpClient = new HttpClient();
            if (method==null)
            {
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/{controller}{"/"}{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonString = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<Tentity>(jsonString);
                    return values;
               }
            }
            else
            {
                var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/{controller}{"/"}{method}{"/"}{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Tentity>(jsonString);
                return values;
            }
            }
            return default(Tentity);
        }

        [HttpPost]
        public static async Task<bool> EditTentityAsync(string controller,Tentity tentity)
        {
            var httpClient = new HttpClient();
            var jsonBlog = JsonConvert.SerializeObject(tentity);
            StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync($"https://localhost:7111/api/{controller}",
             content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        public static async Task<Tentity?> GetTentityAsync(string controller,string method)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/{controller}{"/"}{method}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Tentity>(jsonString);
                return values;
            }
            return default(Tentity);
        }

        [HttpGet]
        public static async Task<List<Tentity?>> GetMessagesByEmailTentityAsync(string controller,string method,string mail)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/{controller}{"/"}{method}{"/"}{mail}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Tentity>>(jsonString);
                return values;
            }
            return null;
        }

        [HttpGet]
        public static async Task<int> GetMessagesCountByEmailTentityAsync(string controller, string method, string mail)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/{controller}{"/"}{method}{"/"}{mail}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<int>(jsonString);
                return values;
            }
            return default;
        }
    }
}
