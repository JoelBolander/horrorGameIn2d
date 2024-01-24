using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFlashlight : MonoBehaviour
{
    // Speed at which the object rotates
    public float rotationSpeed = 5f;

    void Update()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the object to the mouse position
        Vector3 direction = mousePos - transform.position;

        // Calculate the angle between the object and the mouse position
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg)-90;

        // Rotate the object towards the mouse position smoothly
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
