# BUSSID Mwanza-Dar Mod - Runtime Systems Guide

## Overview

This directory contains the core runtime C# scripts that manage all game systems. Each script handles a specific aspect of gameplay.

## System Scripts

### 1. **ConfigLoader.cs**
Loads all JSON configuration files at startup.
- Loads 10 configuration files automatically
- Provides access to config data throughout the game
- Caches configs in memory for performance

```csharp
ConfigLoader loader = GetComponent<ConfigLoader>();
loader.LoadAllConfigurations();
string config = loader.GetConfiguration("difficulty_settings");
```

### 2. **DifficultyManager.cs**
Manages game difficulty levels (Easy, Normal, Hard, Extreme).
- 4 difficulty presets with multipliers
- Applies difficulty to all game systems
- Adjusts traffic, damage, fuel, rewards, time limits

```csharp
DifficultyManager difficulty = GetComponent<DifficultyManager>();
difficulty.SetDifficulty("Hard");
// Applies: 1.4x traffic, 1.5x damage, 1.5x rewards
```

### 3. **PoliceSystem.cs**
Handles traffic enforcement and checkpoints.
- 6 checkpoints across the route
- Speed enforcement with dynamic fines
- Toll gates and random inspections
- Fine calculation based on speed violations

```csharp
PoliceSystem police = GetComponent<PoliceSystem>();
int fine = police.CalculateSpeedingFine(60, 90);  // 30 km/h over limit
police.CheckPlayerAtCheckpoint(1, playerSpeed);
```

### 4. **TrafficManager.cs**
Manages NPC traffic behavior and spawning.
- Vehicle pool with 5 types (truck, bus, minibus, sedan, SUV)
- Dynamic traffic density by time of day
- 4 traffic levels: Peak, Normal, Evening, Night
- AI vehicle selection based on probability

```csharp
TrafficManager traffic = GetComponent<TrafficManager>();
TrafficManager.VehicleTemplate vehicle = traffic.GetRandomVehicle();
traffic.SetTrafficMultiplier(1.5f);  // 50% more traffic
```

### 5. **MissionSystem.cs**
Handles mission creation, tracking, and rewards.
- 5 mission types with different reward structures
- Dynamic time limits based on distance
- Penalty calculation for late missions
- Earnings tracking

```csharp
MissionSystem missions = GetComponent<MissionSystem>();
missions.CreateMission("delivery", 50);  // 50 km delivery
missions.CompleteMission(missionId, 45);  // Complete in 45 minutes
int earnings = missions.GetTotalEarnings();
```

### 6. **WeatherSystem.cs**
Manages dynamic weather effects.
- 4 weather types: Clear, Rain, Fog, Heavy Rain
- Affects visibility (30-500m)
- Reduces road grip (5-35%)
- Increases braking distance (1.0-1.5x)

```csharp
WeatherSystem weather = GetComponent<WeatherSystem>();
weather.SetWeather("rain");
WeatherSystem.Weather current = weather.GetCurrentWeather();
Debug.Log($"Visibility: {current.visibility}m, Grip loss: {current.roadGripReduction}");
```

### 7. **DayNightCycle.cs**
Manages 24-hour day/night cycle.
- Realistic sun positioning and light intensity
- 6 AM sunrise → 6.5 PM sunset
- Twilight phase (6.5 PM - 8 PM)
- Night mode with reduced lighting
- Time events (headlights required at 8 PM)

```csharp
DayNightCycle dayNight = GetComponent<DayNightCycle>();
float time = dayNight.GetTimeOfDay();  // 0-24 hours
string formatted = dayNight.GetTimeFormatted();  // "14:30"
bool night = dayNight.IsNightTime();  // true/false
```

## Integration Guide

### Setup in Scene

1. **Create Manager GameObject**
   ```csharp
   GameObject managerObj = new GameObject("GameManager");
   ```

2. **Add Scripts**
   ```csharp
   managerObj.AddComponent<ConfigLoader>();
   managerObj.AddComponent<DifficultyManager>();
   managerObj.AddComponent<PoliceSystem>();
   managerObj.AddComponent<TrafficManager>();
   managerObj.AddComponent<MissionSystem>();
   managerObj.AddComponent<WeatherSystem>();
   managerObj.AddComponent<DayNightCycle>();
   ```

3. **Initialize**
   ```csharp
   ConfigLoader loader = managerObj.GetComponent<ConfigLoader>();
   loader.LoadAllConfigurations();
   ```

### Usage Example

```csharp
public class GameController : MonoBehaviour
{
    private ConfigLoader configLoader;
    private DifficultyManager difficultyManager;
    private MissionSystem missionSystem;
    private TrafficManager trafficManager;
    private DayNightCycle dayNight;
    private PoliceSystem police;
    private WeatherSystem weather;

    void Start()
    {
        // Load all systems
        configLoader = GetComponent<ConfigLoader>();
        configLoader.LoadAllConfigurations();

        // Set difficulty
        difficultyManager = GetComponent<DifficultyManager>();
        difficultyManager.SetDifficulty("Normal");

        // Start mission
        missionSystem = GetComponent<MissionSystem>();
        missionSystem.CreateMission("delivery", 50);
    }

    void Update()
    {
        // Monitor time of day
        string time = dayNight.GetTimeFormatted();
        
        // Check for traffic density changes
        var density = trafficManager.GetCurrentTrafficDensity((int)dayNight.GetTimeOfDay());
    }
}
```

## Event System Integration

```csharp
// Subscribe to time events
dayNight.OnSunrise += OnSunrise;
dayNight.OnSunset += OnSunset;
dayNight.OnHeadlightsRequired += OnHeadlightsRequired;

// Mission events
missionSystem.OnMissionCompleted += OnMissionCompleted;
missionSystem.OnMissionFailed += OnMissionFailed;

// Police events
police.OnSpeedingDetected += OnSpeedingDetected;
police.OnCheckpointPassed += OnCheckpointPassed;
```

## Performance Considerations

1. **Traffic Manager**
   - Limits concurrent vehicles based on difficulty
   - Easy: ~10 vehicles max
   - Normal: ~20 vehicles max
   - Hard: ~30 vehicles max
   - Extreme: ~40 vehicles max

2. **Weather System**
   - Changes every 5 minutes (configurable)
   - Less frequent in heavy traffic
   - Reduces draw distance in fog/rain

3. **Day/Night Cycle**
   - Lightweight: ~2 update calls per frame
   - Only affects sun light transform
   - Caches time calculations

4. **Config Loader**
   - Loads once at startup
   - Caches all data in memory
   - No runtime file I/O

## Debugging

### Enable Debug Logs
```csharp
// In any system script
Debug.Log("System initialized");
Debug.LogWarning("Config not found");
Debug.LogError("System failed");
```

### Monitor Performance
```csharp
// Check active vehicles
Debug.Log($"Active NPC vehicles: {trafficManager.GetActiveVehicleCount()}");

// Check mission status
Debug.Log($"Active missions: {missionSystem.GetActiveMissionCount()}");

// Monitor weather
Debug.Log($"Current visibility: {weather.GetCurrentWeather().visibility}m");
```

## API Reference

### ConfigLoader
- `LoadAllConfigurations()` - Load all configs
- `GetConfiguration(configName)` - Get specific config

### DifficultyManager
- `SetDifficulty(difficultyName)` - Set game difficulty
- `GetCurrentDifficulty()` - Get active difficulty

### PoliceSystem
- `CalculateSpeedingFine(limit, speed)` - Calculate fine
- `CheckPlayerAtCheckpoint(id, speed)` - Check checkpoint
- `GetCheckpoint(id)` - Get checkpoint data

### TrafficManager
- `GetRandomVehicle()` - Get random vehicle
- `SetTrafficMultiplier(multiplier)` - Adjust traffic
- `GetCurrentTrafficDensity(hour)` - Get density

### MissionSystem
- `CreateMission(type, distance)` - Create mission
- `CompleteMission(id, time)` - Complete mission
- `GetTotalEarnings()` - Get player earnings

### WeatherSystem
- `SetWeather(type)` - Change weather
- `GetCurrentWeather()` - Get weather data

### DayNightCycle
- `GetTimeOfDay()` - Get current hour (0-24)
- `GetTimeFormatted()` - Get formatted time "HH:MM"
- `IsNightTime()` - Check if night

## Troubleshooting

**Issue:** Configs not loading
- **Solution:** Verify JSON files are in Assets/Map/Config/
- Check JSON syntax at jsonlint.com

**Issue:** Traffic not spawning
- **Solution:** Check TrafficManager is initialized
- Verify traffic multiplier isn't 0
- Check spawn interval isn't too high

**Issue:** Police system not working
- **Solution:** Verify checkpoint positions match route
- Check player speed calculation is correct
- Ensure checkpoints are marked active

**Issue:** Day/night cycle not changing
- **Solution:** Verify sun light is assigned in inspector
- Check time scale isn't 0
- Verify cycle speed > 0

## Next Steps

1. Test each system individually
2. Integrate with BUSSID Mod Editor
3. Export to .bussidmod
4. Playtest on Android device
5. Optimize for target devices
