using CarBook.Application.Dtos.ContactDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IApiService _apiService;

        public ContactController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreateContactDto createContactDto)
        {
            //Set the date of the message
            createContactDto.SendDate = DateTime.Now;
            //Convert the object to a JSON string
            var createContactJson = JsonConvert.SerializeObject(createContactDto);
            //Create a StringContent object with the JSON string
            var stringContent = new StringContent(createContactJson, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("https://localhost:7116/api/Contacts", stringContent);

            return RedirectToAction(nameof(Index));
        }
    }
}
