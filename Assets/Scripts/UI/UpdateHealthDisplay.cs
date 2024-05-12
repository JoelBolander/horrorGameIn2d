using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateHealthDisplay : MonoBehaviour
{
    private playerHealth healthScr;

    void Start()
    {
        healthScr = GameObject.FindGameObjectWithTag("player").GetComponent<playerHealth>();
    }

    void Update()
    {
        transform.GetComponent<TextMeshProUGUI>().text = healthScr.health.ToString() + "/" + healthScr.maxHealth.ToString();
    }
}
