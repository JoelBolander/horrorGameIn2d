using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class refuelCampfire: MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("player");
    }

    private void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) <= 2 && Input.GetKeyDown(KeyCode.R) && player.GetComponent<InventoryManager>().twigs >= 2)
        {
            transform.GetComponent<Light2D>().intensity += 0.1f;
            if (transform.GetComponent<Light2D>().intensity > 1)
            {
                transform.GetComponent<Light2D>().intensity = 1;
            }
            player.GetComponent<InventoryManager>().twigs -= 2;
        }
    }
}
