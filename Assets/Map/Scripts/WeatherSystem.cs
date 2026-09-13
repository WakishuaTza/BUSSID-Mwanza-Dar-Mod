using UnityEngine;
using System.Collections.Generic;

public class WeatherSystem : MonoBehaviour
{
    [System.Serializable]
    public class Weather
    {
        public string weatherType;  // clear, rain, fog, wind
        public float intensity;  // 0-1 scale
        public float visibility;
        public float roadGripReduction;
        public float brakingDistanceIncrease;
        public bool affectsAudio;
    }

    private Weather currentWeather;
    private Dictionary<string, Weather> weatherTemplates = new Dictionary<string, Weather>();
    private float weatherChangeTimer = 0;
    private float weatherChangeDuration = 300;  // 5 minutes

    private void InitializeWeatherTemplates()
    {
        weatherTemplates["clear"] = new Weather
        {
            weatherType = "clear",
            intensity = 0,
            visibility = 500,
            roadGripReduction = 0,
            brakingDistanceIncrease = 1.0f,
            affectsAudio = false
        };

        weatherTemplates["rain"] = new Weather
        {
            weatherType = "rain",
            intensity = 0.7f,
            visibility = 100,
            roadGripReduction = 0.15f,  // 15% reduction
            brakingDistanceIncrease = 1.3f,
            affectsAudio = true
        };

        weatherTemplates["fog"] = new Weather
        {
            weatherType = "fog",
            intensity = 0.5f,
            visibility = 50,
            roadGripReduction = 0.05f,
            brakingDistanceIncrease = 1.1f,
            affectsAudio = false
        };

        weatherTemplates["heavy_rain"] = new Weather
        {
            weatherType = "heavy_rain",
            intensity = 1.0f,
            visibility = 30,
            roadGripReduction = 0.35f,
            brakingDistanceIncrease = 1.5f,
            affectsAudio = true
        };
    }

    public void SetWeather(string weatherType)
    {
        if (weatherTemplates.ContainsKey(weatherType))
        {
            currentWeather = weatherTemplates[weatherType];
            Debug.Log($"Weather changed to: {currentWeather.weatherType} (Visibility: {currentWeather.visibility}m)");
        }
    }

    public Weather GetCurrentWeather()
    {
        return currentWeather;
    }

    private void Update()
    {
        weatherChangeTimer += Time.deltaTime;
        if (weatherChangeTimer >= weatherChangeDuration)
        {
            RandomizeWeather();
            weatherChangeTimer = 0;
        }
    }

    private void RandomizeWeather()
    {
        string[] weatherTypes = { "clear", "rain", "fog", "heavy_rain" };
        string randomWeather = weatherTypes[Random.Range(0, weatherTypes.Length)];
        SetWeather(randomWeather);
    }
}
