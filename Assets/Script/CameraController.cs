using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{    
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public Camera mainCamera; 
    public GameObject FirstFloor;
    public GameObject SecondFloor;

    void Start()
    {
        FirstFloor.SetActive(false);
        
    }
    //2층 올라가는 함수
    public void SecondStair()
    {
        StartCoroutine(SmoothMove(new Vector3(4, 2.5f, mainCamera.transform.position.z)));
        SecondFloor.SetActive(false);
        Invoke("Delay2", 2f);
        Debug.Log("2");
        FirstFloor.SetActive(true);
    }
    //1층 내려가는 함수
    public void FirstStair()
    {
        StartCoroutine(SmoothMove(new Vector3(-3.5f, -2, mainCamera.transform.position.z)));
        FirstFloor.SetActive(false);
        Invoke("Delay2", 2f);
        Debug.Log("1");
        SecondFloor.SetActive(true);
    }

    void Delay2()
    {
        //2초 딜레이 함수
    }

    IEnumerator SmoothMove(Vector3 target)
    {
        while (Vector3.Distance(mainCamera.transform.position, target) > 0.05f)
        {
            mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, target, ref velocity, smoothTime);
            yield return null;
        }
    }

}
