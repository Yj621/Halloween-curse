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
    public bool isMoving;
    void Start()
    {
        targetY = point1Y;
    }

    void move(){
        if(Mathf.Abs(transform.position.y - targetY)<0.1f)
        {
            if (isMoving)
                targetY = point1Y;
            else
                targetY = point2Y;
            
            isMoving = !isMoving;
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
            // 여기서 필요한 작업을 수행하세요.
            // 예를 들어, 플레이어와의 충돌에 따른 게임 오버 처리 등
        }
    }
}
