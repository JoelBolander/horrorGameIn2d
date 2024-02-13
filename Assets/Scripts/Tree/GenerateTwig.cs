using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTwig : MonoBehaviour
{
    public GameObject twig;
    public void makeTwig(Vector2 treeLocation)
    {
        Vector2 position = new Vector2(treeLocation.x, treeLocation.y);
        if (Random.Range(0, 2) == 1)
        {
            position.x += Random.Range(1000, 1500)/1000;
        } else
        {
            position.x -= Random.Range(1000, 1500) / 1000;
        }
        if (Random.Range(0, 2) == 1)
        {
            position.y += Random.Range(1000, 1500) / 1000;
        }
        else
        {
            position.y -= Random.Range(1000, 1500) / 1000;
        }

        GameObject newTree = Instantiate(twig, position, Quaternion.identity);
    }
}
