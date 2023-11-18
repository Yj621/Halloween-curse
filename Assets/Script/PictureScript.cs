using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureScript : MonoBehaviour
{
    public GameObject before;
    public GameObject after;

    bool imgstatus = false;
    

    void Start()
    {
        after.SetActive(false);
        before.SetActive(false);
        
    }


    void picture()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            imgstatus = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            imgstatus = false;
            before.SetActive(false);
            after.SetActive(false);
        }


        if (imgstatus)
        {
            if (Item.piece == true)
            {
                after.SetActive(true);
            }
            else
            {
                before.SetActive(true);
            }

        }

    }

    
    void Update()
    {
        picture();
    }
}
