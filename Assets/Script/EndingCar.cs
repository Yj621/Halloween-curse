using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCar : MonoBehaviour
{
    public float moveSpeed = 3f;
    public static bool isEnding;
    public Camera mainCamera;

    void Start()
    {
        isEnding = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isEnding = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            isEnding = false;
        }

        if (isEnding)
        {
        
            Debug.Log("heello");
            Vector3 targetPosition = new Vector3(transform.position.x, 16.0f, 0f);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
