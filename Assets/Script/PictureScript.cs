using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureScript : MonoBehaviour
{
    public GameObject before;
    public GameObject after;
    public bool play = false;

    bool imgstatus = false;
    

    void Start()
    {
        after.SetActive(false);
        before.SetActive(false);
        
    }


    void picture()
    {
        imgstatus = true;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            imgstatus = false;
            before.SetActive(false);
            after.SetActive(false);
            play = false;
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
        if (Input.GetKeyDown(KeyCode.F3))
        {
            play = true;
        }
        if (play)
        {
            picture();
        }
        
    }
}
