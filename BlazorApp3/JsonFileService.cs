using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;

namespace BlazorApp3
{
    public class JsonFileService
    {
        private readonly HttpClient _httpClient;

        public JsonFileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> ReadJsonFileAsync<T>(string filePath)
        {
            // O caminho do arquivo deve ser relativo ao wwwroot
            _httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
            {
                NoCache = true
            };
            var response = await _httpClient.GetAsync(filePath);
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();

            // Desserializa a string em um objeto C#
            return JsonSerializer.Deserialize<T>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Opção para ignorar a diferenciação entre maiúsculas e minúsculas nas propriedades
            });
        }
    }
}
