using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCollidingTrees : MonoBehaviour
{
    private CircleCollider2D Collider;

    private void Start()
    {
        Collider = GetComponent<CircleCollider2D>();
        CheckTreeOverlap();
    }

    private void CheckTreeOverlap()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(Collider.bounds.center, Collider.bounds.size, 0f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.CompareTag("Tree"))
            {
                Destroy(gameObject);
            }
        }
    }
}
