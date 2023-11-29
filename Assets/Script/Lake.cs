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
            Debug.Log("A");
            lakeState.Fish1();
        }        
        else if (Random.Range(0f, 1f) <= 0.2f)
        {
            Debug.Log("B");
        }
        else if (Random.Range(0f, 1f) <= 0.4f)
        {
            Debug.Log("Candy");
            Item.isCandy2 = true;
        }
    }
}