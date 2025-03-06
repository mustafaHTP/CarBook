using CarBook.Application.Dtos.AuthDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.Persistence.Filters;
using CarBook.WebApp.Models.AuthModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarBook.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IJwtService _jwtService;
        private readonly IApiService _apiService;

        public AuthController(IHttpClientFactory httpClientFactory, IJwtService jwtService, IApiService apiService)
        {
            _httpClientFactory = httpClientFactory;
            _jwtService = jwtService;
            _apiService = apiService;
        }

        public IActionResult Register()
        {
            TempData["ReturnUrl"] = HttpContext.Request.Query["ReturnUrl"].ToString();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(ValidationFilterAttribute<RegisterAppUserViewModel>))]
        public async Task<IActionResult> Register([FromForm] RegisterAppUserViewModel registerAppUserViewModel)
        {
            var registerAppUserDto = new RegisterAppUserDto
            {
                FirstName = registerAppUserViewModel.FirstName,
                LastName = registerAppUserViewModel.LastName,
                AppUserRole = Domain.Enums.AppUserRole.User,
                Email = registerAppUserViewModel.Email,
                Password = registerAppUserViewModel.Password,
            };

            var content = new StringContent(
                content: JsonConvert.SerializeObject(registerAppUserDto),
                encoding: Encoding.UTF8,
                mediaType: "application/json");

            var response =
                await _apiService.PostAsync("https://localhost:7116/api/Auth/register", content);
            if (!response.IsSuccessful)
            {
                return View(registerAppUserViewModel);
            }

            var returnUrl = TempData["ReturnUrl"]?.ToString();
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }

            return Redirect(returnUrl);
        }

        public IActionResult Login()
        {
            TempData["ReturnUrl"] = HttpContext.Request.Query["ReturnUrl"].ToString();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(ValidationFilterAttribute<LoginAppUserViewModel>))]
        public async Task<IActionResult> Login([FromForm] LoginAppUserViewModel loginAppUserViewModel)
        {
            var loginAppUserDto = new LoginAppUserDto
            {
                Email = loginAppUserViewModel.Email,
                Password = loginAppUserViewModel.Password
            };
            var content = new StringContent(
                JsonConvert.SerializeObject(loginAppUserDto),
                Encoding.UTF8,
                "application/json");
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync(
                "https://localhost:7116/api/Auth/login",
                content);

            if (!response.IsSuccessStatusCode) return View(loginAppUserViewModel);

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LoginAppUserResultDto>(responseContent);

            var token = result.Token;

            // Retrieve claims from the token
            var claimsDict = new Dictionary<string, string?>
                {
                    { JwtRegisteredClaimNames.Sub, _jwtService.GetClaimValue(token, JwtRegisteredClaimNames.Sub) },
                    { JwtRegisteredClaimNames.GivenName, _jwtService.GetClaimValue(token, JwtRegisteredClaimNames.GivenName) },
                    { JwtRegisteredClaimNames.FamilyName, _jwtService.GetClaimValue(token, JwtRegisteredClaimNames.FamilyName) },
                    { JwtRegisteredClaimNames.Email, _jwtService.GetClaimValue(token, JwtRegisteredClaimNames.Email) },
                    { ClaimTypes.Role, _jwtService.GetClaimValue(token, ClaimTypes.Role) }
                };

            // Check if any claim is null or empty
            if (claimsDict.Values.Any(string.IsNullOrEmpty))
            {
                // Handle missing claims (e.g., return an error or log it)
                return BadRequest("Invalid token: Some claims are missing.");
            }

            // Construct claims list
            var claims = claimsDict.Select(kv => new Claim(kv.Key, kv.Value!)).ToList();
            claims.Add(new Claim("AccessToken", result.Token));

            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = _jwtService.GetTokenExpirationDate(token),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                JwtBearerDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            var returnUrl = TempData["ReturnUrl"]?.ToString();
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }

            return Redirect(returnUrl);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}

