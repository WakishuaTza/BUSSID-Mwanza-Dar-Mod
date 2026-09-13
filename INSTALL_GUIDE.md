# BUSSID Mwanza-Dar Mod - Installation & Troubleshooting

## System Requirements

### Development (Building the Mod)
- **Operating System:** Windows 10/11
- **RAM:** 8 GB minimum (16 GB recommended)
- **Disk Space:** 50 GB free (Unity + Mod Editor + Project)
- **Unity Version:** 2019.4.40f1 LTS
- **BUSSID Mod Editor:** Latest version from Maleo Studio

### Playing the Mod (On Device)
- **Game:** BUSSID (Bus Simulator Indonesia)
- **Android Version:** 6.0 or higher
- **RAM:** 2 GB minimum (4 GB recommended)
- **Storage:** 1.5 GB for mod file

## Installation Steps

### For Developers

1. **Clone the Repository**
   ```bash
   git clone https://github.com/WakishuaTza/BUSSID-Mwanza-Dar-Mod.git
   cd BUSSID-Mwanza-Dar-Mod
   ```

2. **Install Unity 2019.4 LTS**
   - Download from: https://unity3d.com/download/download_unity.aspx?thank-you=update&download_nid=62512
   - Install with default settings

3. **Setup BUSSID Mod Editor**
   - Visit: https://maleostudio.com
   - Download Mod Editor
   - Install on Windows

4. **Import Project into Unity**
   - Open BUSSID Mod Editor
   - Create new "Map" project
   - Copy `Assets/Map` folder from this repo into your Mod Editor project

5. **Load Data**
   - All JSON data files are in `Assets/Map/Data/`
   - Editor tools will automatically parse them

6. **Build the Route**
   - In Unity Editor: Tools → MwanzaDar → (1-4)
   - Or follow BUILD_GUIDE.md step by step

### For End Users (Playing)

1. **Download the .bussidmod File**
   - Available from BUSSID Mod Manager
   - Or download releases from this repo

2. **Install on Mobile Device**
   - Place .bussidmod in: `/Android/data/com.mobidev.bussid/files/Mods/`
   - Or use BUSSID's built-in mod installer

3. **Launch BUSSID**
   - Open BUSSID app
   - Go to Mods
   - Select "Mwanza → Dar es Salaam"
   - Enjoy!

## Troubleshooting

### Issue: "Unity version mismatch"
**Solution:** Use exactly Unity 2019.4.40f1. Download from official site or use Unity Hub.

### Issue: "Mod Editor won't open project"
**Solution:** 
- Ensure Assets/Map folder is copied correctly
- Verify folder permissions (not read-only)
- Re-import SDK in Mod Editor

### Issue: "Road gaps between sections"
**Solution:**
- Check waypoint coordinates in waypoints.json
- Ensure road prefabs have proper LOD transitions
- Run: Tools → MwanzaDar → 1 (full route rebuild)

### Issue: "Floating buildings/trees"
**Solution:**
- Verify terrain height in sections.json matches placement
- Check terrain mesh colliders
- Rebuild vegetation scatter with adjusted height offset

### Issue: "Poor performance on device"
**Solution:**
- Enable LOD for vegetation (3 levels)
- Reduce traffic density in traffic_schedule.json
- Lower draw distance in device settings
- Use mobile-optimized prefabs

### Issue: "Traffic paths not working"
**Solution:**
- Verify traffic paths follow road geometry
- Check traffic path connections at waypoints
- Rebuild paths: Tools → MwanzaDar → Traffic Setup

### Issue: "Spawn/Restore points not appearing"
**Solution:**
- Verify spawn_restore.json is valid JSON
- Check position coordinates are within map bounds
- Ensure marker prefabs are assigned in SpawnPointManager

## Performance Tips

### For Developers
- Use prefab instancing for buildings and vegetation
- Implement LOD groups for distant objects
- Bake static geometry meshes
- Use texture atlasing for road/building materials
- Cap shadow-casting light objects (night lighting)

### For Players
- Lower shadow quality in BUSSID settings
- Reduce draw distance for vegetation
- Disable fancy reflections on water
- Close background apps to free RAM
- Use device with 4GB+ RAM for best experience

## FAQ

**Q: Can I modify this mod?**
A: Yes! Fork the repo and create your own version. Follow BUSSID Mod Editor guidelines.

**Q: How long is the route?**
A: 102 km in-game (1:10 scale = ~1,020 km real-world distance).

**Q: How many towns are included?**
A: 12 cities: Mwanza, Misungwi, Shinyanga, Tinde, Nzega, Shelui, Singida, Manyoni, Dodoma, Morogoro, Chalinze, Dar es Salaam.

**Q: Is there traffic?**
A: Yes! Dynamic traffic schedule with rush hours (6-9 AM, 4-7 PM) and quiet nights.

**Q: Are there missions?**
A: This is a map mod. Missions can be added by you or through BUSSID's mod ecosystem.

**Q: What's the highest point on the route?**
A: Dodoma at 1,650m elevation. Lowest is Dar es Salaam at 55m (sea level).

## Support

For help:
- Check existing GitHub Issues
- Create a new Issue with details
- Join BUSSID community forums
- Visit Maleo Studio website

## License
This project is provided as-is for BUSSID community use.
