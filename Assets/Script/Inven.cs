using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inven : MonoBehaviour
{  
    public GameObject[] objectsToDeactivate;
    Player thePlayer;
    
    void Start()
    {
        thePlayer = FindObjectOfType<Player>();
        DeactivateObjects();
    }

    // Update is called once per frame
    void Update()
    {
        if(thePlayer.isKey)
        {
            Debug.Log("Keyyy");
            objectsToDeactivate[0].SetActive(true);
        }
        if(thePlayer.isCarKey)
        {
            Debug.Log("CarKey");
            objectsToDeactivate[1].SetActive(true);
        }
        if(thePlayer.isCandy1)
        {
            Debug.Log("isCandy1");
            objectsToDeactivate[2].SetActive(true);
        }     
        if(Player.isCandy2)
        {
            Debug.Log("isCandy2");
            objectsToDeactivate[3].SetActive(true);
        } 
        if(thePlayer.isRod)
        {
            Debug.Log("isRod");
            objectsToDeactivate[4].SetActive(true);
        }        
    }
    
    void DeactivateObjects()
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
    }
}
