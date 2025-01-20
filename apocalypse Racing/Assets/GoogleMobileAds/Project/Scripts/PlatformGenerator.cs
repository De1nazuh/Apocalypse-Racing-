using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numberOfPlatforms = 20;
    public float levelWidth = 10f;
    public float minY = -2f;
    public float maxY = 2f;
    public float platformSpacing = 5f;

    private float lastPlatformX;

    void Start()
    {
        lastPlatformX = transform.position.x;
        GeneratePlatforms();
    }

    void GeneratePlatforms()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            Vector3 spawnPosition = new Vector3();
            spawnPosition.x = lastPlatformX + platformSpacing;
            spawnPosition.y = Random.Range(minY, maxY);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            lastPlatformX = spawnPosition.x;
        }
    }
}