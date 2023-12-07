using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lake : MonoBehaviour
{
    LakeState lakeState;
    SoundManager soundManager;

    void Start() 
    {
        lakeState = FindObjectOfType<LakeState>();    
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Update()
    {
        
    }
    public int Fish()
    {
        if (Random.Range(0f, 1f) <= 0.2f)
        {
            lakeState.Fish1();
            return 1;
        }        
        else if (Random.Range(0f, 1f) <= 0.2f)
        {
            lakeState.Fish2();
            Debug.Log("Fish2");
            return 2;
        }        
        else if (Random.Range(0f, 1f) <= 0.2f)
        {
            lakeState.Fish3();
            Debug.Log("Fish3");
            return 100;
        }        
        else if (Random.Range(0f, 1f) <= 0.2f)
        {
            lakeState.Bottle();
            Debug.Log("Bottle");
            return 3;
        }
        else if (Random.Range(0f, 1f) <= 0.2f)
        {
            lakeState.Sock();
            Debug.Log("Sock");
            return 4;
        }
        else if (Random.Range(0f, 1f) <= 0.3f)
        {
            Item.isCandy2 = true;
            soundManager.PlayItemGetSound();
            Debug.Log("Candy");
            return 5;
        }
        return 1;
    }   
}