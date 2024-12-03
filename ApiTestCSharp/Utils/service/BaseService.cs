namespace ApiTestCSharp.Utils.service;

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class BaseService
{
    private readonly HttpClient _httpClient;

    public BaseService(string baseUri, string token = "")
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUri)
            
        };

        // Configuración común de encabezados
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }

    // Método para enviar solicitudes GET
    public async Task<T?> GetAsync<T>(string endpoint)
    {
        var response = await _httpClient.GetAsync(endpoint);

        response.EnsureSuccessStatusCode(); // Lanza excepción si no es exitoso

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(content);
    }

    // Método para enviar solicitudes POST
    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        
        var jsonData = JsonConvert.SerializeObject(data);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(endpoint, content, cancellationToken: CancellationToken.None);

        response.EnsureSuccessStatusCode(); // Lanza excepción si no es exitoso
        Console.WriteLine(response.ToString());

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TResponse>(responseContent);
    }

    // Método para enviar solicitudes PUT
    public async Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        var jsonData = JsonConvert.SerializeObject(data);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync(endpoint, content);

        response.EnsureSuccessStatusCode(); // Lanza excepción si no es exitoso

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TResponse>(responseContent);
    }

    // Método para enviar solicitudes DELETE
    public async Task DeleteAsync(string endpoint)
    {
        var response = await _httpClient.DeleteAsync(endpoint);

        response.EnsureSuccessStatusCode(); // Lanza excepción si no es exitoso
    }
}
