using GoFitMobile.Interfaces;
using GoFitMobile.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace GoFitMobile.Services;
public class WorkoutService : BaseService, IWorkoutService
{
    private readonly AppSettings _appSettings;
    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public WorkoutService(
        IOptions<AppSettings> appSettings,
        HttpClient httpClient)
    {
        _appSettings = appSettings.Value;
        _httpClient = httpClient;
        
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task CreateNewWorkoutPlanAsync(WorkoutPlan workoutPlan)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("WorkoutPlan", workoutPlan);
        }
        catch (Exception ex)
        {

        }
    }

    public async Task<List<WorkoutPlan>> ListWorkoutPlansByAthletIdAsync(Guid id)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"WorkoutPlan/Athlete/{id}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                var workoutPlans = JsonSerializer.Deserialize<List<WorkoutPlan>>(content, _jsonSerializerOptions) ?? [];
                
                return workoutPlans;
            }
        }
        catch (Exception ex)
        {

        }

        return [];
    }
}
