using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.Contact
{
    public class SendMessage:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7111/api/Default/SendMessage");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<MessageVM>>(jsonString);
            return View(values);
        }
    }
}
