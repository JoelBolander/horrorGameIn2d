using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckTree : MonoBehaviour
{
    private GameObject player;
    private float timeWhenHit = 0;
    private float currentTime = 0;
    [SerializeField] private float cooldownTime = 1;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    private void Update()
    {
        currentTime = Time.time;
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentTime-timeWhenHit > cooldownTime && !player.GetComponent<placeObject>().place)
        {
            Collider2D[] overlappingObjects = Physics2D.OverlapBoxAll(gameObject.transform.position, gameObject.GetComponent<SpriteRenderer>().bounds.size, 0f);
            if (overlappingObjects.Length > 0)
            {
                foreach (Collider2D collider in overlappingObjects)
                {
                    if (collider.gameObject.CompareTag("Tree"))
                    {
                        timeWhenHit = Time.time;
                        collider.gameObject.GetComponent<GenerateTwig>().makeTwig(collider.gameObject.transform.position);
                        break;
                    }
                }
            }
        }
    }
}
