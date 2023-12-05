using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Player의 아이템 소지 여부를 저장하는 스크립트입니다.
    // 테스트하면서 보기 쉽게 public으로 선언해주세요. 근데 왜 안보이지....
    // static으로 선언하면 메모리에 계속 남기 때문에 어느 스크립트건 값을 가져올 수 있습니다.
    // 사용법: Item.갖고올변수      
    public static bool sheet = false;
    public static bool piece = false;
    public static bool isKey = false;
    public static bool isCarKey = false;
    public static bool isRod = true;    
    public static bool isCandy1 = false;
    public static bool isCandy2 = false;
    public static bool isShovel = false;
    public static bool isScissors = false;
    public static bool isBattery = false;
    public static bool isOil = false;
    public static bool isWheel = false;
    public static bool isCarKey2 = false;
    public static bool canEnding = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        /*if(Input.GetButtonDown("1"))
        {
            isKey = true;
            isBattery = true;
        }
        if(Input.GetButtonDown("2"))
        {
            isCarKey = true;
        }
        if(Input.GetButtonDown("3"))
        {
            isRod = true;
        }
        */
    }
}
