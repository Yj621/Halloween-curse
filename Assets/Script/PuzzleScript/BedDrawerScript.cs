using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedDrawerScript : MonoBehaviour
{
    public GameObject bedDrawerUI;
    public GameObject batteryUI;
    void Start()
    {
        bedDrawerUI.SetActive(false);
        batteryUI.SetActive(false);
    }

    void Update()
    {
        if (Item.isBattery)
        {
            batteryUI.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            bedDrawerUI.SetActive(false);
    }

    public void BedDrawer()
    {
        bedDrawerUI.SetActive(true);
    }
    public void Battery()
    {
        Debug.Log("CLick");
        Item.isBattery = true;
        bedDrawerUI.SetActive(false);
    }

}
