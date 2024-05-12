using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class campfireLight : MonoBehaviour
{
    private Transform campLight;
    private Light2D light;

    private float time = 0;
    private float waitTime = 1f;

    private void Start()
    {
        campLight = transform.GetChild(0);
        light = campLight.gameObject.GetComponent<Light2D>();
    }

    void Update()
    {
        if (Time.realtimeSinceStartup - time >= waitTime)
        {
            light.intensity -= 0.04f;
            if (light.intensity < 0)
            {
                light.intensity = 0;
            }
            time = Time.realtimeSinceStartup;
        }
    }
}
