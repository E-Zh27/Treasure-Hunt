using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public GameObject treasurePrefab;
    public int numberOfTreasures = 10;
    public GameObject plane; 

    void Start()
    {
        SpawnTreasures();
    }

    void SpawnTreasures()
    {
        // Calculate the plane's boundaries based on its size
        MeshRenderer planeRenderer = plane.GetComponent<MeshRenderer>();
        float planeWidth = planeRenderer.bounds.size.x / 2;
        float planeLength = planeRenderer.bounds.size.z / 2;
        Vector3 planeCenter = plane.transform.position;

        for (int i = 0; i < numberOfTreasures; i++)
        {
            float randomX = Random.Range(-planeWidth, planeWidth);
            float randomZ = Random.Range(-planeLength, planeLength);
            Vector3 randomPosition = new Vector3(randomX + planeCenter.x, planeCenter.y + 1, randomZ + planeCenter.z);

            Instantiate(treasurePrefab, randomPosition, Quaternion.identity);
        }
    }
}
