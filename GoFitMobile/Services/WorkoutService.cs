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
    private readonly Uri _uri;

    public WorkoutService(
        IOptions<AppSettings> appSettings,
        HttpClient httpClient)
    {
        _appSettings = appSettings.Value;
        _httpClient = httpClient;
        
        _uri = new Uri(_appSettings.GoFitApiUrl);
    }

    public async Task CreateNewWorkoutPlanAsync(WorkoutPlan workoutPlan)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_uri + "WorkoutPlan", workoutPlan);
        }
        catch (Exception ex)
        {

        }
    }

    public async Task<List<WorkoutPlan>> ListWorkoutPlansByAthletIdAsync(Guid id)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_uri + $"WorkoutPlan/Athlete/{id}");

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
