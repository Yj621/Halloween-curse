using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KoreanTyper;
//using TMPro;

public class Typer : MonoBehaviour
{
    string originText; //Ÿ���� ȿ�� �� �ؽ�Ʈ
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
        int typingLength = originText.GetTypingLength(); // Ÿ���� ���� ��������

        //Ÿ���� ���̷� �ݺ��� �����ϸ鼭 Typing �Լ��� text�� ��ȯ ��Ŵ 
        for (int index = 0; index <= typingLength; index++)
        {
            myText.text = originText.Typing(index); 
            yield return new WaitForSeconds(0.05f); // ������ �ֱ� 
        }
    }
}
