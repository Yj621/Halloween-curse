using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map1Camera : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public GameObject player;

    public float minX = -2.13f;
    public float maxX = 2.13f;
    public float minY = -1.5f;
    public float maxY = 1.5f;

    // public float minX = -3.8f;
    // public float maxX = 4.3f;
    // public float minY = -4.3f;
    // public float maxY = 3.0f;

    private void Update()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        Vector3 newPosition = this.transform.position + moveVector;

        // X�� ����
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Y�� ����
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        this.transform.position = newPosition;
    }
}
