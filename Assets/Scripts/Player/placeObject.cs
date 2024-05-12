using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class placeObject : MonoBehaviour
{
    private GameObject player;

    public bool place = false;
    private GameObject objectToPlace;

    private GameObject previewObject;
    private GameObject placedObject;

    public bool currentlyPlaceable = false;

    [SerializeField] private GameObject campfire;

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("player")[0];
    }

    private void Update()
    {
        if (!place)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                place = true;
                objectToPlace = campfire;
                previewObject = Instantiate(objectToPlace, new Vector3(0, 0, 0), Quaternion.identity);
                previewObject.transform.GetChild(0).gameObject.GetComponent<Light2D>().enabled = false;
                previewObject.transform.GetChild(0).gameObject.GetComponent<refuelCampfire>().enabled = false;
                previewObject.transform.GetChild(0).gameObject.GetComponent<generateWarmth>().enabled = false;
            }
        }

        if (place)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                place = false;
                Destroy(previewObject);
            }

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            previewObject.transform.position = new Vector2(mousePos.x, mousePos.y);

            if (currentlyPlaceable) {
                if(Input.GetKeyDown(KeyCode.Mouse0)) {
                    if (objectToPlace == campfire)
                    {
                        player.GetComponent<InventoryManager>().twigs -= 25;
                    }
                    placedObject = Instantiate(objectToPlace, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
                    placedObject.GetComponent<isPlaceable>().enabled = false;
                    Destroy(previewObject);
                    currentlyPlaceable = false;
                    place = false;
                }
            }
        }
    }
}
