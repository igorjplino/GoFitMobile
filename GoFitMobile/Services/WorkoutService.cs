using GoFitMobile.Interfaces;
using GoFitMobile.Models;
using System.Text.Json;

namespace GoFitMobile.Services;

public class WorkoutService : IWorkoutService
{
    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public WorkoutService(
        HttpClient httpClient)
    {
        _httpClient = httpClient;

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }
}
