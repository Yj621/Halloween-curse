using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPartsScript : MonoBehaviour
{
    public GameObject oil_UI;
    public GameObject wheel_UI;
    public GameObject carkey2_UI;

    public GameObject Oil;
    public GameObject wheel;
    public GameObject carkey2;
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
            Oil.SetActive(false);
        }
        if(Item.isWheel)
        {
            wheel_UI.SetActive(true);
            wheel.SetActive(false);
        }
        if(Item.isCarKey2)
        {
            carkey2_UI.SetActive(true);
            carkey2.SetActive(false);
        }
    }
}
