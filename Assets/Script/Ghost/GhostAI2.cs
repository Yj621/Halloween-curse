using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI2 : MonoBehaviour
{
    public float[] pointX = {3.27f,1.7f,0.85f,0.85f};
    public float[] pointY = {2.17f,2.17f,1.18f,6.9f};
    public float moveSpeed = 3f;
    public float targetX;
    public float targetY;
    public bool isMoving;

    public int waypoint;
    void Start()
    {
        isMoving = false;
        waypoint = 0;
        targetX = pointX[1];
        targetY = pointY[1];
    }

    void move(){
        Debug.Log(transform.position);
        

        
        Vector3 targetPosition = new Vector3(targetX, targetY,0f);
        transform.position = Vector3.MoveTowards(transform.position,targetPosition, moveSpeed * Time.deltaTime);
        
    }
    
    void Update()
    {
        move();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("충돌!");
            
        }
    }
}