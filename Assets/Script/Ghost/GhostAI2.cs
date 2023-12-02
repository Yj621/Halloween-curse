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
        waypoint = 2;
        transform.position = new Vector3(pointX[0],pointY[0],0f);
    }

    void move(){
        
        if (waypoint==1&& isMoving == true)
        {
            targetX = pointX[0];
            targetY = pointY[0];
            if (transform.position.x == 3.27&& waypoint == 1)
            {
                Debug.Log(waypoint);
                waypoint++;
                isMoving = false;
                Debug.Log("test");
            }
        }
        if (waypoint == 2 && isMoving == false)
        {
            
            targetX = pointX[1];
            targetY = pointY[1];
            if(transform.position.x -pointX[1]< 0.1f && waypoint == 2)
            {
                Debug.Log(waypoint);
                waypoint++;
                isMoving = true;
            }
        }
        if (waypoint == 3 && isMoving == true)
        {
            targetX = pointX[2];
            targetY = pointY[2];
            if (Mathf.Abs(transform.position.y) == 1.27f && waypoint == 3)
            {
                Debug.Log(waypoint);
                waypoint++;
                isMoving = false;
            }
        }
        if (waypoint==4&& isMoving == false)
        {
            targetX = pointX[3];
            targetY = pointY[3];
            if (Mathf.Abs(pointY[3]) - Mathf.Abs(transform.position.y)< 0.1f && waypoint == 4)
            {
                Debug.Log(waypoint);
                waypoint++;
                isMoving = true;
            }
        }
        if (waypoint==5&& isMoving == true)
        {
            
            targetX = pointX[1];
            targetY = pointY[1];
            if (Mathf.Abs(transform.position.y) == 2.17f && waypoint == 5)
            {
                Debug.Log(waypoint);
                waypoint = 1;
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