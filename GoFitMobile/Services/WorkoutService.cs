using GoFitMobile.Interfaces;
using GoFitMobile.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace GoFitMobile.Services;
public class WorkoutService : BaseService, IWorkoutService
{
    private readonly AppSettings _appSettings;
    private readonly HttpClient _httpClient;

    public WorkoutService(
        IOptions<AppSettings> appSettings,
        HttpClient httpClient)
    {
        _appSettings = appSettings.Value;
        _httpClient = httpClient;
    }

    public async Task<List<WorkoutPlan>> ListWorkoutPlansByAthletIdAsync(Guid id)
    {
        try
        {
            var uri = new Uri(_appSettings.GoFitApiUrl);

            HttpResponseMessage response = await _httpClient.GetAsync(uri + $"WorkoutPlan/Athlete/{id}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<WorkoutPlan>>(content) ?? [];
            }
        }
        catch (Exception ex)
        {

        }

        return [];
    }
}
