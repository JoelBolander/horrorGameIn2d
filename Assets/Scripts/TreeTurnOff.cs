using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TreeTurnOff : MonoBehaviour
{
    private GameObject player;
    public float maxDistance = 5f;

    private bool isInRange = false;
    // private GameObject thisObject;
    private SpriteRenderer render;
    private CircleCollider2D collide;
    private ShadowCaster2D shadow;
    private RemoveCollidingTrees remover;

    void Start()
    {
        render = gameObject.GetComponent<SpriteRenderer>();
        collide = gameObject.GetComponent<CircleCollider2D>();
        shadow = gameObject.GetComponent<ShadowCaster2D>();
        remover = gameObject.GetComponent<RemoveCollidingTrees>();

        render.enabled = false;
        collide.enabled = false;
        shadow.enabled = false;
        remover.enabled = false;

        player = GameObject.Find("Player");
        //thisObject = gameObject;
    }

    void Update()
    {
        if (player != null && Vector2.Distance(transform.position, player.transform.position) > maxDistance)
        {
            if (isInRange)
            {
                //thisObject.SetActive(false);
                render.enabled = false;
                collide.enabled = false;
                shadow.enabled = false;
                remover.enabled = false;

                isInRange = false;
            }
        }
        else
        {
            if (!isInRange)
            {
                //thisObject.SetActive(true);
                render.enabled = true;
                collide.enabled = true;
                shadow.enabled = true;
                remover.enabled = true;

                isInRange = true;
            }
        }
    }
}
