using UnityEngine;

public class RestrictPlayer : MonoBehaviour
{
    public GameObject terrain; // Assign the terrain object in the inspector
    private float terrainWidth;
    private float terrainLength;
    private Vector3 terrainPosition;

    void Start()
    {
        // Get the terrain's dimensions and center position
        Terrain terrainComponent = terrain.GetComponent<Terrain>();
        terrainWidth = terrainComponent.terrainData.size.x / 2;
        terrainLength = terrainComponent.terrainData.size.z / 2;
        terrainPosition = terrain.transform.position;
    }

    void Update()
    {
        RestrictPlayerWithinTerrain();
    }

    void RestrictPlayerWithinTerrain()
    {
        Vector3 playerPosition = transform.position;

        // Clamp the player's x and z position within terrain boundaries
        float clampedX = Mathf.Clamp(playerPosition.x, terrainPosition.x - terrainWidth, terrainPosition.x + terrainWidth);
        float clampedZ = Mathf.Clamp(playerPosition.z, terrainPosition.z - terrainLength, terrainPosition.z + terrainLength);

        // Update the player's position if they exceed the boundaries
        if (playerPosition.x != clampedX || playerPosition.z != clampedZ)
        {
            transform.position = new Vector3(clampedX, playerPosition.y, clampedZ);
        }
    }
}
