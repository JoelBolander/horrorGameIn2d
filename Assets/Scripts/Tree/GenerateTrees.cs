using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GenerateTrees : MonoBehaviour
{
    public GameObject prefabToPlace;
    public int PrefabsPer100 = 10;
    public float minX = 0f;
    public float maxX = 10f;
    public float minY = 0f;
    public float maxY = 10f;
    public int seed = 42;
    public static List<GameObject> trees = new List<GameObject>();

    private int numberOfPrefabs;

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
        foreach (var item in trees)
        {
            Destroy(item);
        }
        trees.Clear();

        numberOfPrefabs = Mathf.RoundToInt(((Mathf.Abs(minX) + maxX)*(Mathf.Abs(minY)+maxY)/100))*PrefabsPer100;

        UnityEngine.Random.InitState(seed);

        for (int i = 0; i < numberOfPrefabs; i++)
        {
            float randomX = UnityEngine.Random.Range(minX, maxX);
            float randomY = UnityEngine.Random.Range(minY, maxY);

            Vector2 randomPosition = new Vector2(randomX, randomY);

            GameObject newTree = Instantiate(prefabToPlace, randomPosition, Quaternion.identity);
            newTree.transform.parent = transform;
            newTree.transform.position = new Vector3(newTree.transform.position.x, newTree.transform.position.y, 0);

            trees.Add(newTree);
        }
    }
}
