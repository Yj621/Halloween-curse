using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lake : MonoBehaviour
{
    LakeState lakeState;

    void Start() 
    {
        lakeState = FindObjectOfType<LakeState>();    
    }
    void Update()
    {
        
    }
    public void Fish()
    {
        if (Random.Range(0f, 1f) <= 0.2f)
        {
            lakeState.Fish1();
        }        
        else if (Random.Range(0f, 1f) <= 0.2f)
        {
            lakeState.Fish2();
            Debug.Log("Fish2");
        }        
        else if (Random.Range(0f, 1f) <= 0.2f)
        {
            lakeState.Fish2();
            Debug.Log("Bottle");
        }
        else if (Random.Range(0f, 1f) <= 0.2f)
        {
            lakeState.Sock();
            Debug.Log("Sock");
        }
        else if (Random.Range(0f, 1f) <= 0.4f)
        {
            Item.isCandy2 = true;
            Debug.Log("Candy");
        }
    }
}