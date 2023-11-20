using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //오브젝트 아이디에 따라 생성될 대화 내용 저장 오브젝트 아이디는 objectData 스크립트에서 지정 
    Dictionary<int, string[]> dialogueData;

    private void Awake()
    {
        dialogueData = new Dictionary<int, string[]>();
        GenerateData();
    }
    void GenerateData()
    {
        dialogueData.Add(1, new string[] { "테스트", "다이어로그", "입니다." }); // id, 대화 내용
    }
    public string GetDialogue(int id, int dialogueIndex)
    {
        if (dialogueIndex == dialogueData[id].Length) return null; //문자이 끝나면 null return
        else return dialogueData[id][dialogueIndex];
    }
}
