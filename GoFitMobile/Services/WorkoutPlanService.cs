using GoFitMobile.Interfaces;
using GoFitMobile.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace GoFitMobile.Services;
public class WorkoutPlanService : BaseService, IWorkoutPlanService
{
    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public WorkoutPlanService(
        HttpClient httpClient)
    {
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

    public async Task<WorkoutPlan?> GetWortkoutPlanByIdAsync(Guid id)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"WorkoutPlan/{id}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<WorkoutPlan>(content, _jsonSerializerOptions);
            }
        }
        catch (Exception ex)
        {
        }

        return null;
    }
}
