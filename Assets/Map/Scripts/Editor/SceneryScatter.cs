using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class SceneryData
{
    public List<VegetationSpawn> vegetation;
}

[System.Serializable]
public class VegetationSpawn
{
    public string type;  // acacia, baobab, palm, grass
    public int count;
    public float spreadRadius;
    public string section;
}

public class SceneryScatter : MonoBehaviour
{
    public GameObject[] treePrefabs;
    public GameObject grassPrefab;
    private List<GameObject> spawnedVegetation = new List<GameObject>();

    public void ScatterVegetationAlongRoute(RouteBuilder routeBuilder, int section)
    {
        // Randomize tree placement based on section terrain
        // ~2,500+ trees per region
        Debug.Log($"Scattering vegetation for section {section}");

        int treeCount = Random.Range(200, 350);  // Per 10km section
        for (int i = 0; i < treeCount; i++)
        {
            Vector3 randomPos = GetRandomPositionAlongRoute(routeBuilder);
            GameObject tree = SpawnRandomTree(randomPos);
            spawnedVegetation.Add(tree);
        }
    }

    private Vector3 GetRandomPositionAlongRoute(RouteBuilder routeBuilder)
    {
        Vector3 basePos = routeBuilder.GetWaypointPosition(Random.Range(1, 12));
        Vector3 randomOffset = new Vector3(
            Random.Range(-50, 50),
            0,
            Random.Range(-50, 50)
        );
        return basePos + randomOffset;
    }

    private GameObject SpawnRandomTree(Vector3 position)
    {
        if (treePrefabs.Length == 0) return null;

        GameObject treePrefab = treePrefabs[Random.Range(0, treePrefabs.Length)];
        GameObject tree = Instantiate(treePrefab, position, Quaternion.identity);
        return tree;
    }

    public void ClearVegetation()
    {
        foreach (var veg in spawnedVegetation)
        {
            DestroyImmediate(veg);
        }
        spawnedVegetation.Clear();
        Debug.Log("Vegetation cleared");
    }
}
