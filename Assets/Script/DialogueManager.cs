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
        dialogueData.Add(2, new string[] { "이것은 쓰레기통입니다." }); //쓰레기통
        dialogueData.Add(3, new string[] { "이것은 TV 입니다." }); //TV
        //dialogueData.Add(1003, new string[] { "이것은, TV 아닙니다" }); //TV
        //dialogueData.Add(10, new string[] { "하얀차다", "차키가 있으면 열 수 있을것 같다" }); //하얀차
        //dialogueData.Add(1010, new string[] { "사탕 하나 겟또다제" }); //열쇠 있을 때 하얀차
        dialogueData.Add(5, new string[] { "이것은 악보입니다." }); //악보
        dialogueData.Add(6, new string[] { "이것은 액자입니다." }); //액자
        dialogueData.Add(7, new string[] { "이것은 피아노입니다." }); //피아노
    }
    public string GetDialogue(int id, int dialogueIndex)
    {
        if (dialogueIndex == dialogueData[id].Length) return null; //문자이 끝나면 null return
        else return dialogueData[id][dialogueIndex];
    }
}
