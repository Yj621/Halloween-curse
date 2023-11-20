using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2Camera : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public GameObject player;

    public float minX = -2.13f;
    public float maxX = 2.13f;
    public float minY = -1.5f;
    public float maxY = 1.5f;

    private void Update()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        Vector3 newPosition = this.transform.position + moveVector;

        // X축 제한
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Y축 제한
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        this.transform.position = newPosition;
    }
}
