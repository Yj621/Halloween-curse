using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KoreanTyper;
//using TMPro;

public class Typer : MonoBehaviour
{
    string originText; //타입핑 효과 전 텍스트
    Text myText;

    private void Awake()
    {
        myText = GetComponent<Text>();
    }
    void Start()
    {
        originText = myText.text;
        myText.text = "";

        StartCoroutine(TypingRoutine());
    }

    IEnumerator TypingRoutine()
    {                                 
        int typingLength = originText.GetTypingLength(); // 타이핑 길이 가져오기

        //타이핑 길이로 반복문 실행하면서 Typing 함수로 text에 반환 시킴 
        for (int index = 0; index <= typingLength; index++)
        {
            myText.text = originText.Typing(index); 
            yield return new WaitForSeconds(0.05f); // 딜레이 주기 
        }
    }
}
