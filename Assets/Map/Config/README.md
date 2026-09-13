# BUSSID Mwanza-Dar Mod - Configuration Reference

## Overview

This directory contains all advanced configuration files for the Mwanza-Dar mod. Each JSON file controls a specific system within the game.

## Configuration Files

### 1. **lighting_config.json**
Controls day/night cycle, street lighting, and headlight requirements.
- Day cycle: 06:00 - 18:30
- Night cycle: 19:00 - 05:59
- Street light intensity: 0.7 (night)
- Headlight requirement: 20:00

### 2. **weather_system.json**
Defines regional climate, rain probability, and weather effects.
- Northern Region (Mwanza-Shinyanga): Tropical savanna
- Central Region (Singida-Dodoma): Highland plateau
- Southern Region (Dar es Salaam): Subtropical coastal
- Rain reduces visibility by 0.4-0.6x
- Wet roads reduce grip by 15%

### 3. **vehicle_physics.json**
Sets road conditions, terrain elevation, and curve dynamics.
- Road grip coefficients: Asphalt (1.0), Wet (0.65), Damaged (0.85)
- Elevation grades: Flat (0.5%), Rolling (2.5%), Mountain (5%)
- Curve speeds: Sharp (40 km/h), Moderate (60 km/h), Gentle (80 km/h)

### 4. **audio_system.json**
Manages engine sounds, ambient audio, and warning systems.
- Engine profiles: Diesel 2.0L (heavy bus), Petrol 1.5L (minibus)
- Ambient sounds by region (birds, wind, urban traffic)
- Road noise intensity scales with vehicle speed

### 5. **police_system.json**
Configures traffic checkpoints, speed enforcement, and penalties.
- 6 checkpoints across the route
- Speed limits: Residential (40 km/h), Highway (100 km/h), Curves (50 km/h)
- Penalties: Speeding (25k-100k), No documents (75k-100k)
- Toll gate at Singida (3,500 TZS)

### 6. **npc_traffic.json**
Defines AI traffic patterns and vehicle behavior.
- Vehicle pool: Trucks (15%), Buses (20%), Minibuses (25%), Sedans (25%)
- Traffic density: Peak hours (15 vehicles/km), Normal (8 vehicles/km), Night (2 vehicles/km)
- AI behaviors: Lane changing, overtaking, accidents (0.05/hour), emergency vehicles

### 7. **poi_system.json**
Lists points of interest (rest stops, fuel stations, markets).
- 7 major POI locations
- Services: Fuel, food, restroom, repair, hotel, bank
- Rest durations: 15-60 minutes

### 8. **mission_templates.json**
Defines mission types and reward structures.
- 5 mission types: Standard delivery, Passenger express, Heavy freight, Night route, Emergency medical
- Base rewards: 5k-15k (+ per-km bonuses)
- Time limits, cargo weights, vehicle requirements

### 9. **difficulty_settings.json**
Configures game difficulty levels (Easy, Normal, Hard, Extreme).
- Traffic density multiplier: 0.6x - 1.8x
- Vehicle damage scale: 0.5x - 2.0x
- Mission reward multiplier: 0.8x - 2.5x
- Player assists toggle for each level
- Realistic features: Fuel, maintenance, fatigue, traffic violations

### 10. **mod_manifest.json**
Metadata about the mod (version, compatibility, assets).
- BUSSID 3.9+ required
- 414 buildings, 2,500 trees, 21 prefabs
- Performance targets: 60 FPS (high-end), 30 FPS (mid-range)

## Customization Guide

### Adjusting Traffic Density
Edit `npc_traffic.json`:
```json
"spawn_interval_seconds": 5  // Lower = more traffic
```

### Changing Speed Limits
Edit `police_system.json`:
```json
"speed_limit_kmh": 80  // Modify checkpoint speeds
```

### Tweaking Difficulty
Edit `difficulty_settings.json`:
```json
"ai_traffic_density_multiplier": 1.2  // Increase for harder game
```

### Modifying Weather
Edit `weather_system.json`:
```json
"rain_probability": 0.5  // 0.0-1.0 scale
```

### Adding New Checkpoints
Edit `police_system.json` - add to `checkpoints` array

### Creating New Missions
Edit `mission_templates.json` - add new template with unique ID

## Best Practices

1. **Always backup** before editing
2. **Validate JSON** at https://jsonlint.com/
3. **Test changes** incrementally
4. **Use consistent formatting** (2-space indentation)
5. **Document custom changes** in version control
6. **Keep performance in mind** (don't overload density)

## Performance Optimization Tips

- **Reduce NPC traffic** by increasing `spawn_interval_seconds`
- **Lower draw distance** in `lighting_config.json`
- **Disable weather effects** if needed (set `enabled: false`)
- **Reduce LOD levels** for lower-end devices
- **Use fewer sound layers** in `audio_system.json`

## Troubleshooting

**Issue:** Game crashes on startup
- **Solution:** Validate all JSON files for syntax errors

**Issue:** Traffic too dense/sparse
- **Solution:** Adjust `spawn_interval_seconds` in `npc_traffic.json`

**Issue:** Checkpoints not working
- **Solution:** Verify checkpoint coordinates match road geometry

**Issue:** Poor FPS on low-end devices
- **Solution:** Enable "Easy" difficulty in `difficulty_settings.json`

## Version History

**v1.0.0** (2026-09-13)
- Initial configuration suite
- 10 system files
- 4 difficulty levels
- Dynamic weather and traffic

## Support

For config issues, create a GitHub issue with:
- JSON file name
- Error message
- Device specs (if performance-related)
- Steps to reproduce
