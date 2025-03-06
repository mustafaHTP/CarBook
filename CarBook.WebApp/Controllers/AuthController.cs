using CarBook.Application.Dtos.AuthDtos;
using CarBook.Application.Interfaces.Services;
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

        public AuthController(IHttpClientFactory httpClientFactory, IJwtService jwtService)
        {
            _httpClientFactory = httpClientFactory;
            _jwtService = jwtService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterAppUserViewModel registerAppUserViewModel)
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginAppUserViewModel loginAppUserViewModel)
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
            if (response.IsSuccessStatusCode)
            {
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

                return RedirectToAction("Index", "Home");
            }

            return View(loginAppUserViewModel);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}

