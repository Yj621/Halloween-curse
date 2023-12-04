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
    public GameObject map2;
    public int gameStart = 0; //게임 시작시 출력할 대화 길이 
    public int gameStart2 = 0;
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
    TVScript tvScript;
    BedDrawerScript bedDrawerScript;
    Lake theLake;
    private bool fnote = true;
    private bool fsheet = true;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        theCamera = FindObjectOfType<CameraController>();
        sceneManage = FindObjectOfType<SceneManage>();
        pianoScript = FindObjectOfType<PianoScript>();
        sheetScript = FindObjectOfType<SheetScript>();
        lockScript = FindObjectOfType<LockScript>();
        bedDrawerScript = FindObjectOfType<BedDrawerScript>();
        tvScript = FindObjectOfType<TVScript>();
        theLake = FindObjectOfType<Lake>();
        noteUI.SetActive(false);
        sheetUI.SetActive(false);
    }
    //이동
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && noteUI.activeSelf)
        {
            NoteClose();

        }
        if (!gameManager.isAction && rigid.constraints == RigidbodyConstraints2D.FreezeAll)
        {
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
            //rigid.constraints = ~RigidbodyConstraints2D.FreezePositionX | ~RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }

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
        if (gameStart2 == 0 && scanObj != null)
        {
            if (scanObj.name == "StartDialogue2")
            {
                gameManager.Action(scanObj);
                gameStart2 += 1;
            }
        }

        // 스캔 오브젝트
        if (Input.GetButtonUp("Jump") && scanObj != null)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            Debug.Log("스캔 오브젝트" + scanObj.name);

            ObjectData objectData = scanObj.GetComponent<ObjectData>();
            if (objectData.id == 0 && gameStart > 4)
            {
                return;
            }
            if (objectData.id == 0)
            {
                gameStart += 1;
            }
            if (objectData.id == 100 && gameStart2 > 2)
            {
                return;
            }
            if (objectData.id == 100)
            {
                gameStart2 += 1;
            }

            if (objectData.id == 7 && Item.sheet && !Item.isScissors) // 피아노, 악보 O 
            {
                objectData.condition = 1;
                pianoScript.piano();
                pianoScript.checkindex = 1;
            }
            
            if (objectData.id == 7 && Item.sheet && Item.isScissors) // 가위 얻은 후
            {
                objectData.condition = 2;
            }
            else if (objectData.id == 5) //악보
            {
                if (fsheet)
                {
                    Item.sheet = true;
                    sheetUI.SetActive(true);
                    pianoScript.SheetActive();
                    fsheet = false;
                }
                
            }
            else if (objectData.id == 6) //선반
            {
                lockScript.LockActiveTrue();
            }
            else if (objectData.id == 10 && Item.isScissors && !Item.isBattery) // 서랍, 가위 O
            {
                objectData.condition = 1;
                bedDrawerScript.BedDrawer();
                bedDrawerScript.ChangeSprite();
            }
            else if (objectData.id == 10 && Item.isBattery) // 서랍, 가위 O
            {
                objectData.condition = 2;
            }
            else if (objectData.id == 11 && Item.isKey == true) // 문, 열쇠가 있을때 대화 생성 X
            {
                return;
            }
            else if (objectData.id == 3 && Item.isBattery == true) // TV, 건전지가 있을때 대화 생성 X
            {
                tvScript.opentv = true;
                return;
            }
            else if (objectData.id == 14) //쪽지 상호작용
            {
                if (fnote)
                {
                    noteUI.SetActive(true);
                    fnote = false;
                }
            }

            else if (objectData.id == 15 && Item.isCandy2) //호수에서 낚시대 들고 상호작용 사탕을 얻은 후
            {
                objectData.condition = 1;
            }

            else if (objectData.id == 15 && Item.isRod == true && !Item.isCandy2) //호수에서 낚시대 들고 상호작용
            {
                if (!fishing)
                {
                    fish = theLake.Fish();
                    objectData.id += fish;
                    objectData.condition = 1;
                    gameManager.Action(scanObj);
                    objectData.condition = 1;
                    objectData.id -= fish;
                    fishing = true;
                }
                else
                {
                    objectData.id += fish;
                    objectData.condition = 1;
                    gameManager.Action(scanObj);
                    objectData.condition = 1;
                    objectData.id -= fish;
                    fishing = false;
                }
                return;
            }
            else if (objectData.id == 24) //삽 상호작용
            {
                Item.isShovel = true;
            }

            else if (objectData.id == 27 && Item.isShovel) //삽이 있으면서 땅 팔때 
            {
                objectData.condition = 0;
                Item.isCarKey = true;
            }

            else if (objectData.id == 21 && Item.isCarKey) //빨간/초록차 상호작용
            {
                objectData.condition = 1;
            }
            else if (objectData.id == 22 && Item.isCarKey) //빨간/초록차 상호작용
            {
                objectData.condition = 1;
            }
            else if (objectData.id == 23 && Item.isCarKey) //하얀차 + 차키 있을때
            {
                Item.isCandy1 = true;
                objectData.condition = 1;
            }
            else if (objectData.id == 25) //석상
            {
                int candys = 0;
                if (Item.isCandy1) candys++;
                if (Item.isCandy2) candys++;
                objectData.condition = candys;
                Debug.Log("candys" + candys);
            }
            else if (objectData.id == 26 && !Item.isRod) //상점 주인
            {
                Item.isRod = true;
            }
            else if (objectData.id == 26 && Item.isRod && gameManager.dialogueIndex == 0) //상점 주인 낚시대 O // gameManager.dialogueIndex == 0 -> 상점주인과 대화 끝날 때까지 기다리기
            {
                objectData.condition = 1;
            }

            else if (objectData.id == 28) //아이템 모두 모았을 때
            {
                if (Item.isOil && Item.isWheel && Item.isCarKey2)
                {
                    objectData.condition = 1;
                }
            }
            if (objectData.id == 29)
            {
                Item.isOil = true;
            }
            else if (objectData.id == 30)
            {
                Item.isWheel = true;
            }
            else if (objectData.id == 31)
            {
                Item.isCarKey2 = true;
            }
            gameManager.Action(scanObj);

        }

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

        //맵 2 입장 조건(나중에 수정)
        if (other.gameObject.tag == "Map2" && Item.isCandy1 && Item.isCandy2)
        {
            Debug.Log("Map2");
            sceneManage.Map2();
            Item.isKey = false;
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
        NoteClose();
    }
    public void NoteClose()
    {
        noteUI.SetActive(false);
    }
}