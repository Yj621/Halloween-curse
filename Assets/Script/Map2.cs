using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2 : MonoBehaviour
{  
    private BoxCollider2D boxCollider; 
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
    }

    void Update()
    {
        if(Item.isCandy1 && Item.isCandy2)
        {
            boxCollider.enabled = true;
            Debug.Log("pass");
        }
    }
}
