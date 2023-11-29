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
        dialogueData.Add(0, new string[] { "테스트", "다이어로그", "입니다." }); // 게임 시작
        //dialogueData.Add(1, new string[] { "테스트", "다이어로그", "입니다." }); // id, 대화 내용
        dialogueData.Add(2, new string[] { "쓰레기가 가득차있다." }); //쓰레기통
        dialogueData.Add(3, new string[] { "작동하지 않는다. 건전지가 없나?" }); //TV
        dialogueData.Add(4, new string[] { "나의 모습이 비친다" }); //거울
        dialogueData.Add(5, new string[] { "악보를 얻었다!" }); //악보
        dialogueData.Add(6, new string[] { "이것은 액자입니다." }); //액자
        dialogueData.Add(7, new string[] { "악보가 있으면 연주 할 수 있을텐데..." }); //피아노
        dialogueData.Add(1007, new string[] { "아까 얻은 악보로 뭔가 할 수 있을 것 같다." }); //피아노, 악보 O
        dialogueData.Add(8, new string[] { "아무것도 없는 것 같다." }); //침대
        dialogueData.Add(9, new string[] { "쇼파 밑에는 먼지만 가득하다." }); //쇼파
        dialogueData.Add(10, new string[] { "무언가로 뜯어서 열어야 한다." }); //서랍
        dialogueData.Add(1010, new string[] { "가위로 테이프를 잘랐다." }); //서랍, 가위 O
        dialogueData.Add(11, new string[] { "열쇠가 있어야 탈출할 수 있을 것 같다." }); //문
        dialogueData.Add(12, new string[] { "작동하지 않는다." }); //시계
        dialogueData.Add(13, new string[] { "작동하지 않는다." }); //가르레인지
    }
    public string GetDialogue(int id, int dialogueIndex)
    {
        if (dialogueIndex == dialogueData[id].Length) return null; //문자이 끝나면 null return
        else return dialogueData[id][dialogueIndex];
    }
}
