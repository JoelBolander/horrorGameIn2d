using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GenerateTrees : MonoBehaviour
{
    public GameObject prefabToPlace;
    public int numberOfPrefabs = 10;
    public float minX = 0f;
    public float maxX = 10f;
    public float minY = 0f;
    public float maxY = 10f;
    public int seed = 42;
    public static List<GameObject> Trees = new List<GameObject>();

    void Start()
    {
        Generation();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Generation();
        }
    }

    private void Generation ()
    {
        foreach (var item in Trees)
        {
            Destroy(item);
        }
        Trees.Clear();

        // Set the seed for reproducibility
        UnityEngine.Random.InitState(seed);

        // Instantiate prefabs at random positions
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            float randomX = UnityEngine.Random.Range(minX, maxX);
            float randomY = UnityEngine.Random.Range(minY, maxY);

            Vector2 randomPosition = new Vector2(randomX, randomY);

            GameObject newTree = Instantiate(prefabToPlace, randomPosition, Quaternion.identity);

            Trees.Add(newTree);
        }
    }
}
