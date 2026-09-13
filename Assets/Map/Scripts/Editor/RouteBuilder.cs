using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class WaypointData
{
    public string route;
    public string scale;
    public float total_distance_km;
    public List<Waypoint> waypoints;
}

[System.Serializable]
public class Waypoint
{
    public int id;
    public string name;
    public float latitude;
    public float longitude;
    public float elevation_m;
    public string type;
}

public class RouteBuilder : MonoBehaviour
{
    public WaypointData waypointData;
    private List<Vector3> routePoints = new List<Vector3>();

    public void LoadWaypoints(TextAsset jsonFile)
    {
        waypointData = JsonUtility.FromJson<WaypointData>(jsonFile.text);
        Debug.Log($"Loaded {waypointData.waypoints.Count} waypoints for route: {waypointData.route}");
    }

    public void GenerateRoadMesh()
    {
        if (waypointData == null || waypointData.waypoints.Count < 2)
        {
            Debug.LogError("Not enough waypoints to generate road");
            return;
        }

        // Convert waypoints to world coordinates (1:10 scale)
        foreach (var waypoint in waypointData.waypoints)
        {
            Vector3 worldPos = new Vector3(
                waypoint.longitude * 100,  // Scale: 1:10
                waypoint.elevation_m / 100,
                waypoint.latitude * 100
            );
            routePoints.Add(worldPos);
        }

        Debug.Log($"Generated {routePoints.Count} route points");
    }

    public Vector3 GetWaypointPosition(int waypointId)
    {
        if (waypointId > 0 && waypointId <= routePoints.Count)
        {
            return routePoints[waypointId - 1];
        }
        return Vector3.zero;
    }
}
