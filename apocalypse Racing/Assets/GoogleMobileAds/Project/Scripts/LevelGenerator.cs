using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public GameObject[] tilePrefabs;

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int x = 0; x < width; x++)
        {
            
            
                Vector2 position = new Vector2(x, 0);
                int randomIndex = Random.Range(0, tilePrefabs.Length);
                Instantiate(tilePrefabs[randomIndex], position, Quaternion.identity);
            
        }
    }
}