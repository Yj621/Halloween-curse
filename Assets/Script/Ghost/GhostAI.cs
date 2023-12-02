using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    public float point1Y = -6.8f;
    public float point2Y = 4.15f;
    public float point1X = -7.19f;
    public float moveSpeed = 3f;
    public float targetY;
    public int waypoint;
    public bool isMoving;
    void Start()
    {
        targetY = point1Y;
        waypoint = 0;
        isMoving = false;
    }

    void move(){
        if (waypoint == 0)
        {
            targetY = point2Y;
            if (point2Y - transform.position.y <0.1f)
            {
                waypoint = 1;
                isMoving = true;
            }
        } 
        if (waypoint == 1&& isMoving == true)
            {
                targetY = point1Y;
                if (transform.position.y - point1Y <0.1f)
            {
                waypoint = 0;
                isMoving = false;
            }
            }
        
        Vector3 targetPosition = new Vector3(transform.position.x, targetY,0f);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
    
    void Update()
    {
        move();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("유령과 충돌했습니다!");
            
        }
        
    }
}
