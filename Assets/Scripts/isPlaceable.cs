using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPlaceable : MonoBehaviour
{
    private GameObject player;
    private placeObject placeObjectScr;
    private int collidingObjects = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        placeObjectScr = player.GetComponent<placeObject>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collidingObjects++;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collidingObjects--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("checkTree"))
        {
            collidingObjects++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("checkTree"))
        {
            collidingObjects--;
        }
    }

    private void Update()
    {
        if (collidingObjects == 0 && player.GetComponent<InventoryManager>().twigs >= 25)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            placeObjectScr.currentlyPlaceable = true;
        } else
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            placeObjectScr.currentlyPlaceable = false;
        }
    }
}
