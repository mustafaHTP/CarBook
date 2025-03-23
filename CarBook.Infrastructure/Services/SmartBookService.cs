using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Dtos.SmartBookDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Services
{
    public class SmartBookService : ISmartBookService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IApiService _apiService;

        public SmartBookService(IHttpClientFactory httpClientFactory, IConfiguration configuration, IApiService apiService)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _apiService = apiService;
        }

        public async Task<SmartBookResponseDto> GetResponseAsync(SmartBookRequestDto smartBookRequestDto)
        {
            //1.Get cars from api and serialize to JSON
            var response =
                await _apiService.GetAsync<IEnumerable<GetCarsDto>>("https://localhost:7116/api/Cars");
            if (!response.IsSuccessful)
            {
                throw new Exception("Failed to get cars");
            }

            var carsJson = JsonConvert.SerializeObject(response.Result);

            //2.Get api key from configuration
            var geminiApiKey = _configuration["SmartBookKey"];

            //3.Prepare prompt
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={geminiApiKey}";

            var prompt = $"User wants a car with these preferences: {smartBookRequestDto.UserInput}. "
                          + "You are a professional car dealer."
                          + $"Here are available cars:\n{carsJson}\n"
                          + "Choose the best match and return JSON in this format but given format must be compatible with Newtonsoft's JsonConvert.DeserializeObject<JObject>:\n"
                          + "{ \"carId\": \"<car_id>\", \"carName\": \"<car_name>\", \"reason\": \"<why this car was chosen, it must be not short or long, could be satisfied customer>\" } "
                          + "Only return valid JSON with no extra text.";

            var jsonPayload = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            var jsonString = JsonConvert.SerializeObject(jsonPayload);
            var content = new StringContent(
                jsonString,
                Encoding.UTF8,
                "application/json");
            var client = _httpClientFactory.CreateClient();

            var geminiResponse = await client.PostAsync(url, content);
            if (!geminiResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Failed to get response from Gemini");
            }

            //4.Deserialize response
            string geminiResponseBody = await geminiResponse.Content.ReadAsStringAsync();
            geminiResponseBody = geminiResponseBody.Trim();
            var geminiResponseJson = JsonConvert.DeserializeObject<JObject>(geminiResponseBody);
            if (geminiResponseJson is null)
            {
                throw new Exception("Failed to deserialize Gemini response");
            }

            /*
             * Extract the response from the 'candidates' array, which contains the best match.
             *
             * The expected JSON structure:
             * {
             *   "candidates": [
             *     {
             *       "content": {
             *         "parts": [
             *           {
             *             "text": "{...}" // The response contains structured text data, including information like car details.
             *           }
             *         ]
             *       }
             *     }
             *   ]
             * }
             *
             * 'candidates' array is expected to hold multiple potential matches, with the most relevant
             * match appearing first. We extract the first entry to get the response we need.
             */
            var smartBookResponseJson = geminiResponseJson["candidates"]?[0]?["content"]?["parts"]?[0]?["text"];
            if (smartBookResponseJson is null)
            {
                throw new Exception("Failed to get SmartBook response");
            }

            smartBookResponseJson = smartBookResponseJson.ToString().Replace("```json", "").Replace("```", "").Trim();

            //5.Deserialize SmartBook response
            var smartBookResponse = JsonConvert.DeserializeObject<SmartBookResponseDto>(smartBookResponseJson.ToString());

            if (smartBookResponse is null)
            {
                throw new Exception("Failed to deserialize SmartBook response");
            }

            if (smartBookResponse.CarId is null || smartBookResponse.Reason is null)
            {
                throw new Exception("Failed to get carId or reason from SmartBook response");
            }

            return smartBookResponse;
        }
    }
}
