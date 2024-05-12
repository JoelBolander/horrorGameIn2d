using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updateTwigDisplay : MonoBehaviour
{
    private InventoryManager invMan;
    private void Start()
    {
        invMan = GameObject.FindGameObjectsWithTag("player")[0].GetComponent<InventoryManager>();
    }

    void Update()
    {
        transform.GetComponent<TextMeshProUGUI>().text = invMan.twigs.ToString();
    }
}
