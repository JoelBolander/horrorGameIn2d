using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTwig : MonoBehaviour
{
    private GameObject player;
    private InventoryManager inventoryManager;

    private bool allowPickup = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        inventoryManager = player.GetComponent<InventoryManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            allowPickup = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            allowPickup = false;
        }
    }
    private void Update()
    {
        if (allowPickup && Input.GetKeyDown(KeyCode.E))
        {
            inventoryManager.twigs += 1;
            Destroy(gameObject);
        }
    }
}
