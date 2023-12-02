using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVScript : MonoBehaviour
{
    public GameObject imgTV;
    public GameObject imgTV2;
    public bool opentv; 
    void Start()
    {
        imgTV.SetActive(false);
        opentv = false;
        
    }


    void Update()
    {
        if (opentv == true)
        {
            imgTV.SetActive(true);
            opentv = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            imgTV.SetActive(false);
        }
        
    }
}
