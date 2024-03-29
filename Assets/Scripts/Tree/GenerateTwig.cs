using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTwig : MonoBehaviour
{
    public GameObject twig;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("player");
    }

    public void makeTwig(Vector2 treeLocation)
    {
        player.GetComponent<playerHealth>().takeDamage(1);

        Vector2 position = new Vector2(treeLocation.x, treeLocation.y);
        if (Random.Range(0, 2) == 1)
        {
            float a = Random.Range(0.5f, 2f);
            position.x += a;
        } else
        {
            float b = Random.Range(0.5f, 2f);
            position.x -= b;
        }
        if (Random.Range(0, 2) == 1)
        {
            position.y += Random.Range(0.5f, 2f);
        }
        else
        {
            position.y -= Random.Range(0.5f, 2f);
        }

        GameObject newTree = Instantiate(twig, position, Quaternion.identity);
    }
}
