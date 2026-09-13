using UnityEngine;
using System.Collections.Generic;

public class TrafficManager : MonoBehaviour
{
    [System.Serializable]
    public class VehicleTemplate
    {
        public string vehicleType;  // truck, bus, minibus, sedan, suv
        public int percentageChance;
        public float speedKmhAvg;
        public float acceleration;
        public string sizeClass;
    }

    [System.Serializable]
    public class TrafficDensity
    {
        public string timeOfDay;
        public int vehiclesPerKm;
        public int spawnIntervalSeconds;
        public List<string> activeHours;
    }

    private List<VehicleTemplate> vehiclePool = new List<VehicleTemplate>();
    private List<TrafficDensity> trafficDensities = new List<TrafficDensity>();
    private float currentTrafficMultiplier = 1.0f;

    private void InitializeVehiclePool()
    {
        vehiclePool.Add(new VehicleTemplate { vehicleType = "truck", percentageChance = 15, speedKmhAvg = 70, acceleration = 0.8f, sizeClass = "large" });
        vehiclePool.Add(new VehicleTemplate { vehicleType = "bus", percentageChance = 20, speedKmhAvg = 75, acceleration = 0.7f, sizeClass = "large" });
        vehiclePool.Add(new VehicleTemplate { vehicleType = "minibus", percentageChance = 25, speedKmhAvg = 80, acceleration = 1.0f, sizeClass = "medium" });
        vehiclePool.Add(new VehicleTemplate { vehicleType = "sedan", percentageChance = 25, speedKmhAvg = 85, acceleration = 1.2f, sizeClass = "small" });
        vehiclePool.Add(new VehicleTemplate { vehicleType = "suv", percentageChance = 15, speedKmhAvg = 80, acceleration = 1.1f, sizeClass = "medium" });
    }

    private void InitializeTrafficDensity()
    {
        trafficDensities.Add(new TrafficDensity
        {
            timeOfDay = "Peak Hours",
            vehiclesPerKm = 15,
            spawnIntervalSeconds = 5,
            activeHours = new List<string> { "06:00-09:00", "16:00-19:00" }
        });

        trafficDensities.Add(new TrafficDensity
        {
            timeOfDay = "Normal",
            vehiclesPerKm = 8,
            spawnIntervalSeconds = 10,
            activeHours = new List<string> { "09:00-16:00" }
        });

        trafficDensities.Add(new TrafficDensity
        {
            timeOfDay = "Evening",
            vehiclesPerKm = 5,
            spawnIntervalSeconds = 15,
            activeHours = new List<string> { "19:00-22:00" }
        });

        trafficDensities.Add(new TrafficDensity
        {
            timeOfDay = "Night",
            vehiclesPerKm = 2,
            spawnIntervalSeconds = 30,
            activeHours = new List<string> { "22:00-06:00" }
        });
    }

    public VehicleTemplate GetRandomVehicle()
    {
        int random = Random.Range(0, 100);
        int accumulated = 0;
        
        foreach (var vehicle in vehiclePool)
        {
            accumulated += vehicle.percentageChance;
            if (random <= accumulated)
            {
                return vehicle;
            }
        }
        return vehiclePool[0];  // Fallback
    }

    public void SetTrafficMultiplier(float multiplier)
    {
        currentTrafficMultiplier = multiplier;
        Debug.Log($"Traffic multiplier set to: {multiplier}x");
    }

    public TrafficDensity GetCurrentTrafficDensity(int currentHour)
    {
        foreach (var density in trafficDensities)
        {
            // Match current hour with active hours
            // Returns appropriate density
        }
        return trafficDensities[1];  // Default to Normal
    }
}
