using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class generateWarmth : MonoBehaviour
{
    private GameObject player;

    private float distance = 0f;
    private float intensity = 0f;

    private float heatGenerated = 0f;

    private float currentTime = 0f;
    private float timeChecked = 0f;

    void Start()
    {
        player = GameObject.FindWithTag("player");
    }

    void Update()
    {
        currentTime = Time.time;

        if (currentTime - timeChecked >= 1)
        {
            distance = Vector2.Distance(player.transform.position, transform.position);
            intensity = GetComponent<Light2D>().intensity;

            intensity *= 11;

            if (intensity > 0 && distance <= intensity)
            {
                heatGenerated = (intensity * (8.5f - distance)) / 50;
                heatGenerated *= 10;
                heatGenerated = Mathf.FloorToInt(heatGenerated);
                heatGenerated /= 10;

                player.GetComponent<PlayerTemperature>().getWarmer(heatGenerated * 2);
            }

            timeChecked = Time.time;
        }
    }
}
