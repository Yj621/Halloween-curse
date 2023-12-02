using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPartsScript : MonoBehaviour
{
    public GameObject oil_UI;
    public GameObject wheel_UI;
    public GameObject carkey2_UI;
    void Start()
    {
        oil_UI.SetActive(false);
        wheel_UI.SetActive(false);
        carkey2_UI.SetActive(false);
    }

    void Update()
    {
        if(Item.isOil)
        {
            oil_UI.SetActive(true);
        }
        if(Item.isWheel)
        {
            wheel_UI.SetActive(true);
            Debug.Log("testWHEEL");
        }
        if(Item.isCarKey2)
        {
            carkey2_UI.SetActive(true);
        }
    }
}
