using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class ConfigLoader : MonoBehaviour
{
    [System.Serializable]
    public class ConfigData
    {
        public string configName;
        public TextAsset jsonFile;
        public bool loaded;
    }

    public List<ConfigData> configurations = new List<ConfigData>();
    private Dictionary<string, object> loadedConfigs = new Dictionary<string, object>();

    public void LoadAllConfigurations()
    {
        Debug.Log("Loading all system configurations...");
        
        LoadConfiguration("lighting_config");
        LoadConfiguration("weather_system");
        LoadConfiguration("vehicle_physics");
        LoadConfiguration("audio_system");
        LoadConfiguration("police_system");
        LoadConfiguration("npc_traffic");
        LoadConfiguration("poi_system");
        LoadConfiguration("mission_templates");
        LoadConfiguration("difficulty_settings");
        LoadConfiguration("mod_manifest");

        Debug.Log($"Loaded {loadedConfigs.Count} configurations successfully");
    }

    private void LoadConfiguration(string configName)
    {
        string path = $"Assets/Map/Config/{configName}.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            loadedConfigs[configName] = json;
            Debug.Log($"✓ Loaded: {configName}");
        }
        else
        {
            Debug.LogWarning($"✗ Config not found: {path}");
        }
    }

    public string GetConfiguration(string configName)
    {
        if (loadedConfigs.ContainsKey(configName))
        {
            return loadedConfigs[configName].ToString();
        }
        Debug.LogError($"Configuration not found: {configName}");
        return null;
    }
}
