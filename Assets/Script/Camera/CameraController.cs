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
    public GameObject testObj;
    public bool stairState = false;

    void Start()
    {
        FirstFloor.SetActive(false);
        
    }
    //2�� �ö󰡴� �Լ�
    public void SecondStair()// 한 오브젝트에 , (아마 한 함수에도) 담아야함. 왜냐면 접촉하는게 두개라서. 하나의 오브젝트로 상호작용하게 하고 bool값으로 카메라 전환.
    {// 두개의 오브젝트를 써서 아래껄 밟으면 그건 bool값만 바뀌도록. 왜냐면 콜라이더 안에서 다시 방향전환을 하면 시점과 플레이어의 위치가 다름.
        /*if (stairState)
        {
            StartCoroutine(SmoothMove(new Vector3(-3.5f, -2, mainCamera.transform.position.z)));
            FirstFloor.SetActive(false);
            stairState = false;
            SecondFloor.SetActive(true);
        }*/

        
            StartCoroutine(SmoothMove(new Vector3(-3.5f, -2, mainCamera.transform.position.z)));
            //StartCoroutine(SmoothMove(new Vector3(4, 2.5f, mainCamera.transform.position.z)));
            stairState = true;
            FirstFloor.SetActive(true);
            SecondFloor.SetActive(false);
            
        
    }
    //1�� �������� �Լ�
    public void FirstStair()
    {   
            StartCoroutine(SmoothMove(new Vector3(4, 2.5f, mainCamera.transform.position.z)));
            //StartCoroutine(SmoothMove(new Vector3(-3.5f, -2, mainCamera.transform.position.z)));
            stairState = false;
            SecondFloor.SetActive(true);
            FirstFloor.SetActive(false);
        
    }

    void Delay2()
    {
        //2�� ������ �Լ�
    }

    IEnumerator SmoothMove(Vector3 target)
    {
        while (Vector3.Distance(mainCamera.transform.position, target) > 0.05f)
        {
            mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, target, ref velocity, smoothTime);
            yield return null;
        }
        //stairState = !stairState;
    }

}
