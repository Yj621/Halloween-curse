using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("플레이어")]
    public float speed;
    Rigidbody2D rigid;
    float h; //Horizontal
    float v; //Vertical
    bool isHorizonMove;
    public bool cameraMove = false;
    public GameMangaer gameManager;
    public GameObject noteUI;
    public GameObject sheetUI;
    public GameObject sheet;
    public GameObject note;
    public GameObject shovel;
    public int gameStart = 0; //게임 시작시 출력할 대화 길이 
    private bool fishing = false;
    private int fish = 0;
    Vector3 dirVec;
    GameObject scanObj;
    Animator anim;
    CameraController theCamera;
    SceneManage sceneManage;
    PianoScript pianoScript;
    SheetScript sheetScript;
    LockScript lockScript;
    Lake theLake;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        theCamera = FindObjectOfType<CameraController>();
        sceneManage = FindObjectOfType<SceneManage>();
        pianoScript = FindObjectOfType<PianoScript>();
        sheetScript = FindObjectOfType<SheetScript>();
        lockScript = FindObjectOfType<LockScript>();
        theLake = FindObjectOfType<Lake>();
        noteUI.SetActive(false);
        sheetUI.SetActive(false);
    }
    //이동
    void Update()
    {

        if (!gameManager.isAction)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            bool hDown = Input.GetButtonDown("Horizontal");
            bool vDown = Input.GetButtonDown("Vertical");
            bool hUp = Input.GetButtonUp("Horizontal");
            bool vUp = Input.GetButtonUp("Vertical");

            //키를 하나 꾹 누르다가 다른 키 누르면 멈추는거 방지하기 위해 || vUp / hUp 추가
            if (hDown)
                isHorizonMove = true;
            else if (vDown)
                isHorizonMove = false;
            else if (hUp || vUp)
                isHorizonMove = h != 0;

            //h와 v 모두 float형이라 형변환해주고, 애니메이션에서 설정한 파라미터값 가져오기
            if (anim.GetInteger("hAxisRaw") != h)
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("hAxisRaw", (int)h);
            }
            else if (anim.GetInteger("vAxisRaw") != v)
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("vAxisRaw", (int)v);
            }
            else
            {
                anim.SetBool("isChange", false);
            }

            if (vDown && v == 1)
            {
                dirVec = Vector3.up;
            }
            else if (vDown && v == -1)
            {
                dirVec = Vector3.down;
            }
            else if (hDown && h == -1)
            {
                dirVec = Vector3.left;
            }
            else if (hDown && h == 1)
            {
                dirVec = Vector3.right;
            }

            //스페이스바 눌렀을때 오브젝트 이름 가져와서 
        }
        if (gameStart == 0 && scanObj != null)
        {
            if (scanObj.name == "StartDialogue")
            {
                gameManager.Action(scanObj);
                gameStart += 1;
            }
        }


        // 스캔 오브젝트
        if (Input.GetButtonDown("Jump") && scanObj != null)
        {
            Debug.Log(scanObj.name);

            ObjectData objectData = scanObj.GetComponent<ObjectData>();
            if (objectData.id == 0 && gameStart > 4)
            {
                return;
            }
            if (objectData.id == 0)
            {
                gameStart += 1;
            }

            if (objectData.id == 7 && Item.sheet == true) // 피아노, 악보 O 
            {
                objectData.condition = true;
                pianoScript.piano();
            }
            else if (objectData.id == 5) //악보
            {
                Item.sheet = true;
                sheetUI.SetActive(true);
                Destroy(sheet);
                pianoScript.SheetActive();
            }
            else if (objectData.id == 6) //선반
            {
                lockScript.LockActive();
            }
            else if (objectData.id == 10 && Item.scissors == true) // 서랍, 가위 O
            {
                objectData.condition = true;
            }
            else if (objectData.id == 11 && Item.isKey == true) // 문, 열쇠가 있을때 대화 생성 X
            {
                return;
            }
            else if (objectData.id == 3 && Item.battery == true) // TV, 건전지가 있을때 대화 생성 X
            {
                return;
            }
            else if (objectData.id == 14) //쪽지 상호작용
            {
                noteUI.SetActive(true);
                Destroy(note);
            }
            
            else if (objectData.id == 15 && Item.isCandy2) //호수에서 낚시대 들고 상호작용 사탕을 얻은 후
            {
                objectData.condition = true;
            }
            
            else if (objectData.id == 15 && Item.isRod == true && !Item.isCandy2) //호수에서 낚시대 들고 상호작용
            {
                //null 리턴이 되고 id 값을 깎아야겠는데
                if (!fishing)
                {
                    fish = theLake.Fish();
                    objectData.id += fish;
                    objectData.condition = true;
                    gameManager.Action(scanObj);
                    objectData.condition = false;
                    objectData.id -= fish;
                    Debug.Log("호수 " + objectData.id);
                    fishing = true;
                }
                else
                {
                    objectData.id += fish;
                    objectData.condition = true;
                    gameManager.Action(scanObj);
                    objectData.condition = false;
                    objectData.id -= fish;
                    Debug.Log("호수 " + objectData.id);
                    fishing = false;
                }
                return;
            }
            else if (objectData.id == 24) //삽 상호작용
            {
                Item.isShovel = true; //hierarchy에 삽 넣어주세요
                Destroy(shovel);
            }
            /*
            else if (objectData.id == 32 && Item.isShovel) //삽이 있으면서 땅 팔때 
            {
                Item.isCarKey = true;
                Destroy(scanObj);
                return; //이부분은 수정 부탁드려요 대사 나오게
            }맵 만들어지면
            */
            else if (objectData.id == 21 && Item.isCarKey) //빨간/초록차 상호작용
            {
                objectData.condition = true;
            }
            else if (objectData.id == 22 && Item.isCarKey) //빨간/초록차 상호작용
            {
                objectData.condition = true;
            }
            else if (objectData.id == 23 && Item.isCarKey) //하얀차 + 차키 있을때
            {
                Item.isCandy1 = true;
                objectData.condition = true;
            }

            gameManager.Action(scanObj);

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
        Debug.DrawRay(rigid.position, dirVec * 0.5f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.5f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObj = rayHit.collider.gameObject;
            //Debug.Log(scanObj.name);
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
        if (other.gameObject.tag == "Map1" && Item.isKey)
        {
            Debug.Log("Map1");
            sceneManage.Map1();
            Item.isKey = false;
        }
        else if (other.gameObject.tag == "Map1" && Item.isKey == false)
        {
            //열쇠 안 갖고 탈출하려 했을때 대화창 뜨도록
        }

        //맵 2 입장 조건(나중에 수정)
        if (other.gameObject.tag == "Map2" && Item.isKey)
        {
            Debug.Log("Map2");
            sceneManage.Map2();
            Item.isKey = false;
        }
        else if (other.gameObject.tag == "Map2" && Item.isKey == false)
        {
            //열쇠 안 갖고 탈출하려 했을때 대화창 뜨도록            
        }

        //상점 들어가기
        if (other.gameObject.tag == "Store")
        {
            transform.position = new Vector2(-8.14f, 1.06f);
            cameraMove = true;
        }
        //상점 나가기
        if (other.gameObject.tag == "StoreExit")
        {
            transform.position = new Vector2(-4.44f, 1.25f);
            cameraMove = false;
        }

    }

    public void BtnNoteClose()
    {
        Debug.Log("close");
        noteUI.SetActive(false);
    }

}