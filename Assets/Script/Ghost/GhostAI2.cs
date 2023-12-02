using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI2 : MonoBehaviour
{
    public float[] pointX = {3.27f,1.33f,1.33f,1.33f};
    public float[] pointY = {2.17f,2.17f,-1.27f,4.79f};
    public float moveSpeed = 3f;
    public float targetX;
    public float targetY;
    public bool isMoving;

    public int waypoint;
    void Start()
    {
        isMoving = false;
        waypoint = 0;
        transform.position = new Vector3(pointX[0],pointY[0],0f);
    }

    void move(){
        Debug.Log(transform.position);
        if (waypoint == 0)
        {
            Debug.Log(transform.position);
            
            targetX = pointX[1];
            targetY = pointY[1];
            if(transform.position.x - pointX[1] < 0.1f)
            {
                waypoint++;
                isMoving = true;
            }
        }
        if (waypoint == 1 && isMoving == true);
        {
            targetX = pointX[2];
            targetY = pointY[2];
            if (Mathf.Abs(pointY[2]) - Mathf.Abs(transform.position.y) < 0.1f)
            {
                waypoint++;
            }

        }
    

    
        

        
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