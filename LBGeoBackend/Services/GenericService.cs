using System.Text.Json;
using System.Net.Http.Json;
using LBGeoBackend.Interfaces;
using LBGeoBackend.Class;
using System.Configuration;
using Microsoft.Extensions.Configuration; // Agrega esta línea



namespace LBGeoBackend.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly HttpClient client;
        protected readonly JsonSerializerOptions options;
        protected readonly string _endpoint;
        public static string jwtToken = string.Empty;

        public GenericService(IConfiguration configuration) // Inyecta IConfiguration
        {
            client = new HttpClient();
            options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            // Lee la URL de la API desde appsettings.json
            string urlApi = configuration["UrlApi"];
            if (configuration["Remoto"] == "false")
                urlApi = configuration["UrlApiLocal"];

            _endpoint = urlApi + ApiEndpoint.GetEndpoint(typeof(T).Name);

            if (!string.IsNullOrEmpty(GenericService<object>.jwtToken))
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GenericService<object>.jwtToken);
            else
                throw new ArgumentException("Error Token no definido", nameof(GenericService<object>.jwtToken));
        }

        public async Task<List<T>?> GetAllAsync(string? filtro = "")
        {
            var response = await client.GetAsync($"{_endpoint}?filtro={filtro}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<T>>(content, options); ;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var response = await client.GetAsync($"{_endpoint}/{id}");
            var content = await response.Content.ReadAsStreamAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<T>(content, options);
        }

        public async Task<T?> AddAsync(T? entity)
        {
            var response = await client.PostAsJsonAsync(_endpoint, entity);
            var content = await response.Content.ReadAsStreamAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<T>(content, options);
        }

        public async Task UpdateAsync(T? entity)
        {
            var idValue = entity.GetType().GetProperty("Id").GetValue(entity);

            var response = await client.PutAsJsonAsync($"{_endpoint}/{idValue}", entity);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(response?.ToString());
            }
        }

        public async Task DeleteAsync(int id)
        {
            var response = await client.DeleteAsync($"{_endpoint}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(response.ToString());
            }
        }
    }
}
