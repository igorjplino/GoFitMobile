using GoFitMobile.Interfaces;
using GoFitMobile.Models;
using System.Text.Json;

namespace GoFitMobile.Services;
public class ExerciseService : IExerciseService
{
    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ExerciseService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<List<Exercise>> GetExerciseListAsync()
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"Exercise");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<Exercise>>(content, _jsonSerializerOptions) ?? [];
            }
        }
        catch (Exception ex )
        {

        }

        return [];
    }
}
