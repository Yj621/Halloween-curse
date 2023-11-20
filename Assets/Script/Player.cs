using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header ("플레이어")]
    public float speed;
    Rigidbody2D rigid;
    float h; //Horizontal
    float v; //Vertical
    bool isHorizonMove;
    public bool isKey = false;
    Vector3 dirVec;
    GameObject scanObj;
    Animator anim;
    CameraController theCamera;
    SceneManage sceneManage;
    PianoScript pianoScript;
    SheetScript sheetScript;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        theCamera = FindObjectOfType<CameraController>();
        sceneManage = FindObjectOfType<SceneManage>();
        pianoScript = FindObjectOfType<PianoScript>();
        sheetScript = FindObjectOfType<SheetScript>();
    }

    //이동
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

    //키를 하나 꾹 누르다가 다른 키 누르면 멈추는거 방지하기 위해 || vUp / hUp 추가
        if(hDown)
            isHorizonMove = true;
        else if(vDown)
            isHorizonMove = false;
        else if(hUp || vUp)
            isHorizonMove = h != 0;

    //h와 v 모두 float형이라 형변환해주고, 애니메이션에서 설정한 파라미터값 가져오기
        if(anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if(anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }
        
        if(vDown && v == 1)
        {
            dirVec = Vector3.up;
        }
        else if(vDown && v == -1)
        {
            dirVec = Vector3.down;
        }
        else if(hDown && h == -1)
        {
            dirVec = Vector3.left;
        }
        else if(hDown && h == 1)
        {
            dirVec = Vector3.right;
        }

        //스페이스바 눌렀을때 오브젝트 이름 가져와서 

        //스캔 오브젝트
        if (Input.GetButtonDown("Jump") && scanObj != null)
        {
            if (scanObj.name == "Sheet")
            {
                sheetScript.sheet();
            }
            else if (scanObj.name == "Frame")
            {
                Debug.Log("2");
            }
            
        }
        
    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;

        //레이
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if(rayHit.collider != null)
        {
            scanObj = rayHit.collider.gameObject;
        }
        else
        {
            scanObj = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SecondStairs")
        {
            theCamera.SecondStair();
        }
        if (other.gameObject.tag == "FirstStairs")
        {
            theCamera.FirstStair();
        }
        //맵 1 입장 조건
        if (other.gameObject.tag == "Map1" && isKey)
        {
            Debug.Log("1");
            sceneManage.Map1();
            isKey = false;
        }
        //맵 2 입장 조건(나중에 수정)
        if (other.gameObject.tag == "Map2" && isKey)
        {
            Debug.Log("2");
            sceneManage.Map2();
            isKey = false;
        }
    }

}