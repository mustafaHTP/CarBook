using CarBook.Application.Dtos.ContactDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IApiService _apiService;

        public ContactController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response =
                await _apiService.GetAsync<IEnumerable<GetContactsDto>>("https://localhost:7116/api/Contacts");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
