using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inven : MonoBehaviour
{  
    public GameObject[] objectsToDeactivate;
    
    void Start()
    {
        DeactivateObjects();
    }

    // Update is called once per frame
    void Update()
    {
        if(Item.isKey)
        {
            Debug.Log("Keyyy");
            objectsToDeactivate[0].SetActive(true);
        }
        if(Item.isCarKey)
        {
            Debug.Log("CarKey");
            objectsToDeactivate[1].SetActive(true);
        }
        if(Item.isCandy1)
        {
            Debug.Log("isCandy1");
            objectsToDeactivate[2].SetActive(true);
        }     
        if(Item.isCandy2)
        {
            Debug.Log("isCandy2");
            objectsToDeactivate[3].SetActive(true);
        } 
        if(Item.isRod)
        {
            Debug.Log("isRod");
            objectsToDeactivate[4].SetActive(true);
        }
        if(Item.isShovel)
        {
            Debug.Log("isShovel");
            objectsToDeactivate[5].SetActive(true);
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
