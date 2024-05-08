using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class placeObject : MonoBehaviour
{
    public bool place = false;
    private GameObject objectToPlace;

    private GameObject previewObject;
    private GameObject placedObject;

    public bool currentlyPlaceable = false;

    [SerializeField] private GameObject campfire;

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
            }
        }

        if (place)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            previewObject.transform.position = new Vector2(mousePos.x, mousePos.y);

            if (currentlyPlaceable) {
                if(Input.GetKeyDown(KeyCode.Mouse0)) {
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
