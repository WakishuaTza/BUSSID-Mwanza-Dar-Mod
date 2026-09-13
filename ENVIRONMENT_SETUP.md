# Development Environment Setup

## Windows Setup (Recommended)

### Prerequisites
```
Windows 10/11 (64-bit)
.NET Framework 4.7.1+
Git for Windows
Visual Studio Code or Visual Studio 2019+
```

### Step 1: Install Git
```bash
# Download from https://git-scm.com/download/win
# Run installer with default settings
```

### Step 2: Install Unity Hub
```bash
# Download: https://unity3d.com/download
# Install and open Unity Hub
```

### Step 3: Install Unity 2019.4 LTS
```bash
# In Unity Hub:
# - Installs → Add 2019.4.40f1
# - Select all components
# - Install to default location: C:\Program Files\Unity\2019.4.40f1
```

### Step 4: Install BUSSID Mod Editor
```bash
# Download from https://maleostudio.com
# Run installer
# Choose installation path (e.g., C:\Maleo\BussidModEditor)
```

### Step 5: Clone This Repository
```bash
cd C:\MyProjects  # or your preferred directory
git clone https://github.com/WakishuaTza/BUSSID-Mwanza-Dar-Mod.git
cd BUSSID-Mwanza-Dar-Mod
```

### Step 6: Setup IDE (Visual Studio Code)
```bash
# Download: https://code.visualstudio.com/
# Extensions to install:
# - Unity Code Snippets
# - C#
# - Debugger for Unity
# - Git Graph
```

## Environment Variables

Optional: Add to system PATH for easier access:
```
UNITY_PATH=C:\Program Files\Unity\2019.4.40f1\Editor\Unity.exe
MALEO_PATH=C:\Maleo\BussidModEditor
```

## Project Structure

```
BUSSID-Mwanza-Dar-Mod/
├── Assets/
│   └── Map/
│       ├── Data/
│       │   ├── waypoints.json
│       │   ├── sections.json
│       │   ├── spawn_restore.json
│       │   ├── prefab_manifest.json
│       │   └── traffic_schedule.json
│       ├── Scripts/
│       │   └── Editor/
│       │       ├── MapBuilder.cs
│       │       ├── RouteBuilder.cs
│       │       ├── SceneryScatter.cs
│       │       ├── TownBuilder.cs
│       │       └── SpawnPointManager.cs
│       ├── Prefabs/
│       │   ├── Roads/
│       │   ├── Vegetation/
│       │   └── Buildings/
│       └── Scenes/
│           └── MainScene.unity
├── ProjectVersion.txt
├── README.md
├── SETUP_FIRST_TIME.md
├── BUILD_GUIDE.md
├── QA_CHECKLIST.md
├── ROADMAP.md
├── CONTRIBUTORS.md
├── INSTALL_GUIDE.md
└── ENVIRONMENT_SETUP.md
```

## First Build

1. **Open in Mod Editor:**
   ```bash
   # Start Mod Editor, select Tools → Open Project
   # Navigate to: C:\..\BUSSID-Mwanza-Dar-Mod
   ```

2. **Verify Installation:**
   - Check Console (should show no errors)
   - Verify Assets/Map folder is recognized
   - Load waypoints.json data

3. **Build Route:**
   - Tools → MwanzaDar → 1. Build Full Route
   - Wait for completion (~2-5 minutes)
   - Check Console for success message

4. **Next Steps:**
   - Follow BUILD_GUIDE.md for complete process
   - Reference QA_CHECKLIST.md for testing

## Development Workflow

### Typical Session
```bash
# 1. Start of day: Pull latest changes
git pull origin main

# 2. Open in Mod Editor
# Tools → MwanzaDar → (select task)

# 3. Make changes to JSON data or C# scripts
# Edit files in your IDE while Mod Editor is open

# 4. Reload in Mod Editor
# File → Reload Project (or restart Mod Editor)

# 5. Test changes
# Export to .bussidmod and test on device

# 6. Commit changes
git add .
git commit -m "Description of changes"
git push origin main
```

## Debugging

### Unity Editor Console
- View → Collapse Console
- Filter by: Errors, Warnings, Logs
- Double-click error to jump to code

### Visual Studio Debugger
- Debug → Attach Unity Debugger
- Set breakpoints in code
- Step through execution

### JSON Validation
```bash
# Validate JSON files before committing
# Use online validator: https://jsonlint.com/
# Or command line:
python -m json.tool Assets/Map/Data/waypoints.json
```

## Performance Profiling

### In Mod Editor
- Window → Profiler
- Monitor: CPU, Memory, Rendering
- Look for performance bottlenecks

### On Device
- BUSSID Settings → Developer Mode
- Enable FPS Counter
- Monitor during gameplay

## Common Commands

```bash
# Clone repo
git clone https://github.com/WakishuaTza/BUSSID-Mwanza-Dar-Mod.git

# Update from remote
git pull origin main

# Create new branch for feature
git checkout -b feature/new-feature-name

# Commit with descriptive message
git commit -m "Add [feature]: description"

# Push to remote
git push origin feature/new-feature-name

# View git log
git log --oneline
```

## Troubleshooting Setup

### Unity Won't Load Project
- Delete Library/ folder (will regenerate)
- Reimport SDK from Asset Store
- Restart Unity Hub

### Mod Editor Crashes
- Update to latest version
- Clear Mod Editor cache: %appdata%\Maleo\
- Reinstall if issues persist

### Git Issues
- Verify credentials: git config --list
- Update git to latest version
- Check .gitignore for accidental exclusions

## Resources

- [Unity Documentation](https://docs.unity3d.com/2019.4/Documentation/)
- [BUSSID Modding Guide](https://www.reddit.com/r/BusSim/wiki/modding)
- [Git Tutorial](https://git-scm.com/book/en/v2)
- [GitHub Docs](https://docs.github.com)

## Next Steps

1. ✅ Complete setup following this guide
2. ✅ Review SETUP_FIRST_TIME.md
3. ✅ Read BUILD_GUIDE.md
4. ✅ Start with ROADMAP.md Phase 1-2
5. ✅ Join community and share progress!
