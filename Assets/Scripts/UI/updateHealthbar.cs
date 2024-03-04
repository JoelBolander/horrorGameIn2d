using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateHealthbar : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float percentage;

    public void changeHealthbar (float health)
    {
        percentage = (health)/(player.GetComponent<playerHealth>().maxHealth);

        transform.localScale = new Vector3(percentage, percentage, 1);
    }
}
