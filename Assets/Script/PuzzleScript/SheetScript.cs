using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetScript : MonoBehaviour
{

    public bool play = false;
    public GameObject imgsheet;

    void Start()
    {
        imgsheet.SetActive(false);
    }


    void sheet()
    {
        Item.sheet = true;
        imgsheet.SetActive(true);

        if( Input.GetKeyDown(KeyCode.Escape))
        {
            imgsheet.SetActive(false);
            play = false;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            play = true;
        }
        if (play)
        {
            sheet();
        }
    }
}
