using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTemperature : MonoBehaviour
{
    private playerHealth healthScr;

    public float MaxTemp = 50f;
    public float MinTemp = -20f;
    public float Temperature = 20f;
    private float damage = 0f;

    private float latestTemperature = 0f;
    private float tempDif = 0f;

    private float currentTime = 0;
    private float updateTime = 0;

    [SerializeField] private GameObject thermometer;
    [SerializeField] private GameObject tempDisplay;
    [SerializeField] private GameObject tempDifDisplay;
    [SerializeField] private GameObject tempDPSDisplay;

    [SerializeField] private Sprite warmImage;
    [SerializeField] private Sprite neutralImage;
    [SerializeField] private Sprite coldImage;

    private void Start()
    {
        healthScr = GameObject.FindGameObjectWithTag("player").GetComponent<playerHealth>();
    }

    public void getColder(float dif)
    {
        Temperature -= dif;

        if (Temperature <= MinTemp)
        {
            Temperature = MinTemp;
        }
    }

    public void getWarmer(float dif)
    {
        Temperature += dif;

        if (Temperature >= MaxTemp)
        {
            Temperature = MaxTemp;
        }
    }

    private void Update()
    {
        currentTime = Time.time;
        
        if (currentTime - updateTime >= 1)
        {
            getColder(1);

            if (Temperature <= 0)
            {
                thermometer.GetComponent<Image>().sprite = coldImage;
            } else if (Temperature >= 30)
            {
                thermometer.GetComponent<Image>().sprite = warmImage;
            } else
            {
                thermometer.GetComponent<Image>().sprite = neutralImage;
            }

            if (Temperature >= 30f)
            {
                damage = Temperature - 30;
            } else if (Temperature >= 10)
            {
                damage =  -(10-Mathf.Abs(Temperature - 20));
            } else if (Temperature >= 0)
            {
                damage = 10 - Temperature;
            } else 
            {
                damage = 10 - Temperature;
            }

            damage = Mathf.FloorToInt(damage);
            damage /= 10;

            if (damage <= 0)
            {
                healthScr.takeHealing(-damage);
                tempDPSDisplay.GetComponent<TextMeshProUGUI>().text = "HPS<br>" + (-damage).ToString();
            } else
            {
                healthScr.takeDamage(damage);
                tempDPSDisplay.GetComponent<TextMeshProUGUI>().text = "DPS<br>" + damage.ToString();
            }

            tempDif = Temperature - latestTemperature;

            Temperature *= 10;
            Temperature = Mathf.FloorToInt(Temperature);
            Temperature /= 10;

            tempDisplay.GetComponent<TextMeshProUGUI>().text = Temperature.ToString() + "°";

            tempDif *= 10;
            tempDif = Mathf.FloorToInt(tempDif);
            tempDif /= 10;

            tempDifDisplay.GetComponent<TextMeshProUGUI>().text = tempDif.ToString() + "°";

            updateTime = Time.time;
            latestTemperature = Temperature;
        }
    }
}
