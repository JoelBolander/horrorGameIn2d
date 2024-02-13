using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckTree : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Collider2D[] overlappingObjects = Physics2D.OverlapBoxAll(gameObject.transform.position, gameObject.GetComponent<SpriteRenderer>().bounds.size, 0f);
            if (overlappingObjects.Length > 0)
            {
                foreach (Collider2D collider in overlappingObjects)
                {
                    if (collider.gameObject.CompareTag("Tree"))
                    {
                        collider.gameObject.GetComponent<GenerateTwig>().makeTwig(collider.gameObject.transform.position);
                        break;
                    }
                }
            }
        }
    }
}
