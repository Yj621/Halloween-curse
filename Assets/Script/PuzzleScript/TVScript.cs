using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVScript : MonoBehaviour
{
    public GameObject imgTV;
    public GameObject imgTV2;
    void Start()
    {
        imgTV.SetActive(false);
        
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            imgTV.SetActive(false);
        }
        
    }
}
