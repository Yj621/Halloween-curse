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
    public bool cameraMove = false;
    public GameMangaer gameManager;

    //테스트를 위해 public으로 선언
    public bool isKey = false;
    public bool isCarKey = false;
    public bool isRod = false;    
    public bool isCandy1 = false;
    public static bool isCandy2 = false;

    bool statueInteraction= false;

    Vector3 dirVec;
    GameObject scanObj;
    Animator anim;
    CameraController theCamera;
    SceneManage sceneManage;
    PianoScript pianoScript;
    SheetScript sheetScript;
    Lake theLake;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        theCamera = FindObjectOfType<CameraController>();
        sceneManage = FindObjectOfType<SceneManage>();
        pianoScript = FindObjectOfType<PianoScript>();
        sheetScript = FindObjectOfType<SheetScript>();
        theLake = FindObjectOfType<Lake>();
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

    // 스캔 오브젝트
    if (Input.GetButtonDown("Jump") && scanObj != null)
    {
            Debug.Log(scanObj.name);
            
            //오류나서 주석처리 했어요
            /*
            ObjectData objectData = scanObj.GetComponent<ObjectData>();
            if (objectData.id == 10 && isCarKey == true) // 하얀차
            {
                objectData.condition = true;
            }
            if (objectData.id == 3 && isCarKey == true) // 하얀차
            {
                Debug.Log("con");
                objectData.condition = true;
            }
            //Debug.Log("scanObj" + scanObj);
            gameManager.Action(scanObj);
            */
            
            
            switch (scanObj.name)
            {
                //악보
                case "Sheet":
                    sheetScript.sheet();
                    break;

                case "Frame":
                    // 액자에 스페이스바 눌렀을 때
                    Debug.Log(scanObj.name);
                    break;

                case "piano":
                    // 피아노에 스페이스바 눌렀을 때
                    Debug.Log(scanObj.name);
                    break;

                case "TV":
                    // TV에 스페이스바 눌렀을 때
                    Debug.Log(scanObj.name);
                    break;

                //선반
                case "Chest":
                    Debug.Log(scanObj.name);
                    break;

                // 쪽지 발견했을때
                case "Note":
                    Debug.Log(scanObj.name);
                    //쪽지 없애기
                    Destroy(scanObj);
                    break;

                //차
                case "RedCar":
                    Debug.Log(scanObj.name);
                    break;
                //차키 있을때만 실행
                case "WhiteCar" when isCarKey == true:
                    Debug.Log("사탕 하나 겟또다제");
                    break;
                //차키 없이 그냥 열었을때는 (차 모두 동일) 차키가 있어야할거같다 or 하얀차다.
                case "WhiteCar":
                    Debug.Log(scanObj.name);
                    isCandy1 = true;
                    break;     

                case "GreenCar":
                    Debug.Log(scanObj.name);
                    break;

                 //낚시대 있을때만 실행
                case "Lake" when isRod == true:
                    Debug.Log("낚시를 해서 ~~%로 사탕얻게도 해야되네");
                    theLake.Fish();
                    break;           

                //호수이다. 무언가 필요하다 대화창
                case "Lake":
                    Debug.Log(scanObj.name);
                    break;

                default:
                    // 처리할 이름이 없을 때의 기본 동작
                    break;
            }
        }
        /*
        //스페이스바 X 그냥 들어갈때        
        if (scanObj != null && scanObj.name == "Statue" && !statueInteraction)
        {
            //사탕을 두개 들고 갔을때
                if(isCandy1 && isCandy2)
                {
                    Debug.Log("사탕 줬으니까 안에 들어가도 된다");
                }
                else
                {
                    Debug.Log("동상:못들어간다! 무언갈 주면 들어보내줄거같다. 근데 한번은 보내주지 않을까?(사탕 얻으러 낚시해야됨)");
                }
                statueInteraction = true;
        }
        else if (scanObj != null && scanObj.name != "Statue" && statueInteraction)
        {
            // Player moved away from the Statue, reset the interaction
            statueInteraction = false;
        }
        */
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
            Debug.Log("Map1");
            sceneManage.Map1();
            isKey = false;
        }
        else if(other.gameObject.tag == "Map1" && isKey == false)
        {
            //열쇠 안 갖고 탈출하려 했을때 대화창 뜨도록
        }

        //맵 2 입장 조건(나중에 수정)
        if (other.gameObject.tag == "Map2" && isKey)
        {
            Debug.Log("Map2");
            sceneManage.Map2();
            isKey = false;
        }
        else if (other.gameObject.tag == "Map2" && isKey == false)
        {
            //열쇠 안 갖고 탈출하려 했을때 대화창 뜨도록            
        }

        //상점 들어가기
        if(other.gameObject.tag == "Store")
        {
            transform.position = new Vector2(-12.228f, -0.319f);
            cameraMove = true;
        }
        //상점 나가기
        if(other.gameObject.tag == "StoreExit")
        {
            transform.position = new Vector2(-4.44f, 1.25f);
            cameraMove = false;
        }
        
    }

}