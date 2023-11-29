using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockScript : MonoBehaviour
{
    public GameObject key;
    void Start()
    {
        key.SetActive(false);
    }
    
    void Update()
    {
        if(Item.isKey)
        {
            key.SetActive(true);
        }
    }

    //여기다 자물쇠 풀기 -> 선반에서 키  얻으면 위 코드에서 isKey가 true가 되도록 하ㅕㅁㄴ 됩니다
    //위 스크립트는 Chest에 있습니다

}
