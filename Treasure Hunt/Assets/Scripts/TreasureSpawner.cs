using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public GameObject treasurePrefab;
    public int numberOfTreasures = 10;
    public Terrain terrain;

    void Start()
    {
        SpawnTreasures();
    }

    void SpawnTreasures()
    {
        // Get the terrain boundaries
        float terrainWidth = terrain.terrainData.size.x;
        float terrainLength = terrain.terrainData.size.z;
        Vector3 terrainPosition = terrain.transform.position;

        for (int i = 0; i < numberOfTreasures; i++)
        {
            // Generate random X and Z positions within the terrain boundaries
            float randomX = Random.Range(0, terrainWidth);
            float randomZ = Random.Range(0, terrainLength);
            
            // Calculate the height at the random X and Z position on the terrain
            float terrainHeight = terrain.SampleHeight(new Vector3(randomX + terrainPosition.x, 0, randomZ + terrainPosition.z));

            // Set the spawn position with the calculated terrain height
            Vector3 randomPosition = new Vector3(randomX + terrainPosition.x, terrainHeight + 1, randomZ + terrainPosition.z);

            Instantiate(treasurePrefab, randomPosition, Quaternion.identity);
        }
    }
}
