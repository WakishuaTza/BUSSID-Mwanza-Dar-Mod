using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class SpawnPoint
{
    public int id;
    public string name;
    public int waypoint_id;
    public Vector3 position;
    public float rotation;
}

[System.Serializable]
public class RestorePoint
{
    public int id;
    public string name;
    public int waypoint_id;
    public Vector3 position;
}

public class SpawnPointManager : MonoBehaviour
{
    public GameObject spawnMarkerPrefab;
    public GameObject restoreMarkerPrefab;

    private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    private List<RestorePoint> restorePoints = new List<RestorePoint>();

    public void CreateSpawnPoints()
    {
        // 6 spawn points at major bus stations
        spawnPoints = new List<SpawnPoint>
        {
            new SpawnPoint { id = 1, name = "Mwanza Bus Station", waypoint_id = 1, position = new Vector3(151.3f, 0, 130.8f), rotation = 0 },
            new SpawnPoint { id = 2, name = "Shinyanga Central", waypoint_id = 3, position = new Vector3(223.4f, 0, 247.3f), rotation = 45 },
            new SpawnPoint { id = 3, name = "Singida Transport Hub", waypoint_id = 7, position = new Vector3(412.7f, 0, 364.7f), rotation = 90 },
            new SpawnPoint { id = 4, name = "Dodoma Main Station", waypoint_id = 9, position = new Vector3(555.6f, 0, 501.6f), rotation = 135 },
            new SpawnPoint { id = 5, name = "Morogoro Depot", waypoint_id = 10, position = new Vector3(827.7f, 0, 569.2f), rotation = 180 },
            new SpawnPoint { id = 6, name = "Dar es Salaam Central", waypoint_id = 12, position = new Vector3(1048.7f, 0, 565.6f), rotation = 225 }
        };

        foreach (var spawn in spawnPoints)
        {
            InstantiateSpawnMarker(spawn);
        }

        Debug.Log($"Created {spawnPoints.Count} spawn points");
    }

    public void CreateRestorePoints()
    {
        // 7 restore points (one per city + Chalinze)
        restorePoints = new List<RestorePoint>
        {
            new RestorePoint { id = 1, name = "Mwanza Restore", waypoint_id = 1, position = new Vector3(160, 0, 135) },
            new RestorePoint { id = 2, name = "Misungwi Restore", waypoint_id = 2, position = new Vector3(180, 0, 170) },
            new RestorePoint { id = 3, name = "Shinyanga Restore", waypoint_id = 3, position = new Vector3(230, 0, 250) },
            new RestorePoint { id = 4, name = "Singida Restore", waypoint_id = 7, position = new Vector3(420, 0, 370) },
            new RestorePoint { id = 5, name = "Dodoma Restore", waypoint_id = 9, position = new Vector3(560, 0, 510) },
            new RestorePoint { id = 6, name = "Morogoro Restore", waypoint_id = 10, position = new Vector3(835, 0, 575) },
            new RestorePoint { id = 7, name = "Dar es Salaam Restore", waypoint_id = 12, position = new Vector3(1055, 0, 570) }
        };

        foreach (var restore in restorePoints)
        {
            InstantiateRestoreMarker(restore);
        }

        Debug.Log($"Created {restorePoints.Count} restore points");
    }

    private void InstantiateSpawnMarker(SpawnPoint spawn)
    {
        if (spawnMarkerPrefab == null) return;
        GameObject marker = Instantiate(spawnMarkerPrefab, spawn.position, Quaternion.Euler(0, spawn.rotation, 0));
        marker.name = $"Spawn_{spawn.name}";
    }

    private void InstantiateRestoreMarker(RestorePoint restore)
    {
        if (restoreMarkerPrefab == null) return;
        GameObject marker = Instantiate(restoreMarkerPrefab, restore.position, Quaternion.identity);
        marker.name = $"Restore_{restore.name}";
    }
}
