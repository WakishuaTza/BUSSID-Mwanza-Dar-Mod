using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class BuildingPlacement
{
    public string townName;
    public Vector3 position;
    public GameObject prefab;
    public string buildingType;  // bus_station, petrol, market, school, police, residential, clinic
}

public class TownBuilder : MonoBehaviour
{
    public GameObject[] buildingPrefabs;
    private List<BuildingPlacement> buildings = new List<BuildingPlacement>();

    // 12 towns with building counts
    private Dictionary<string, int> townBuildingCounts = new Dictionary<string, int>()
    {
        { "Mwanza", 35 },
        { "Misungwi", 18 },
        { "Shinyanga", 50 },
        { "Tinde", 12 },
        { "Nzega", 20 },
        { "Shelui", 8 },
        { "Singida", 45 },
        { "Manyoni", 15 },
        { "Dodoma", 85 },
        { "Morogoro", 55 },
        { "Chalinze", 22 },
        { "Dar es Salaam", 52 }
    };

    public void PlaceAllTownBuildings(RouteBuilder routeBuilder)
    {
        int totalBuildings = 0;
        foreach (var town in townBuildingCounts)
        {
            PlaceTownBuildings(town.Key, town.Value, routeBuilder);
            totalBuildings += town.Value;
        }
        Debug.Log($"Placed {totalBuildings} buildings across 12 towns");
    }

    private void PlaceTownBuildings(string townName, int buildingCount, RouteBuilder routeBuilder)
    {
        Vector3 townCenter = routeBuilder.GetWaypointPosition(GetWaypointIdByTown(townName));

        for (int i = 0; i < buildingCount; i++)
        {
            Vector3 buildingPos = townCenter + new Vector3(
                Random.Range(-100, 100),
                0,
                Random.Range(-100, 100)
            );

            GameObject buildingPrefab = buildingPrefabs[Random.Range(0, buildingPrefabs.Length)];
            GameObject building = Instantiate(buildingPrefab, buildingPos, Quaternion.identity);
            building.name = $"{townName}_Building_{i}";

            buildings.Add(new BuildingPlacement
            {
                townName = townName,
                position = buildingPos,
                prefab = buildingPrefab
            });
        }
    }

    private int GetWaypointIdByTown(string townName)
    {
        return townName switch
        {
            "Mwanza" => 1,
            "Misungwi" => 2,
            "Shinyanga" => 3,
            "Tinde" => 4,
            "Nzega" => 5,
            "Shelui" => 6,
            "Singida" => 7,
            "Manyoni" => 8,
            "Dodoma" => 9,
            "Morogoro" => 10,
            "Chalinze" => 11,
            "Dar es Salaam" => 12,
            _ => 0
        };
    }
}
