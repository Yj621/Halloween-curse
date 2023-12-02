using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI3 : MonoBehaviour
{
    public float[] pointX = {0.1f,8.81f,8.81f,5.85f,5.85f};
    public float[] pointY = {-3.28f,-3.28f,-5.66f,-5.66f,-3.28f};
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
        
        /*if (waypoint==1&& isMoving == true)
        {
            targetX = pointX[0];
            targetY = pointY[0];
            if (transform.position.x == pointX[1]&& waypoint == 1)
            {
                waypoint++;
                isMoving = false;
                Debug.Log("test");
            }
        }*/
        if (waypoint == 2 && isMoving == false)
        {
            targetX = pointX[1];
            targetY = pointY[1];
            if(transform.position.x == pointX[1]&& waypoint == 2)
            {
                waypoint++;
                isMoving = true;
            }
        }
        if (waypoint == 3 && isMoving == true)
        {
            targetX = pointX[2];
            targetY = pointY[2];
            if (transform.position.y == pointY[2] && waypoint == 3)
            {
                waypoint++;
                isMoving = false;
            }
        }
        if (waypoint==4&& isMoving == false)
        {
            targetX = pointX[3];
            targetY = pointY[3];
            if (transform.position.x == pointX[3] && waypoint == 4)
            {
                waypoint++;
                isMoving = true;
            }
        }
        if (waypoint==5&& isMoving == true)
        {
            targetX = pointX[4];
            targetY = pointY[4];
            if (transform.position.y == pointY[4] && waypoint == 5)
            {
                waypoint++;
            }
        }
        if (waypoint==6&& isMoving == true)
        {
            targetX = pointX[0];
            targetY = pointY[0];
            if (transform.position.x == pointX[0] && waypoint == 6)
            {
                Debug.Log(waypoint);
                waypoint = 2;
                isMoving = false;
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