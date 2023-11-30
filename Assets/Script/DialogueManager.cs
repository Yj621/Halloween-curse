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
        dialogueData.Add(0, new string[] { "눈을 떠보니 처음 보는 장소이다.", "창밖에 소란스럽다.", "창밖을 보니 유령들이 돌아 다니고있다.", "빨리 이곳을 탈출해야할 것 같다." }); // 게임 시작
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
        //맵2
        dialogueData.Add(14, new string[] { "상점 전단지이다.", "상점으로 가면 무언갈 얻을 수 있을것 같다." }); //쪽지
        dialogueData.Add(15, new string[] { "큰 호수이다.", "낚시대가 있으면 무언갈 낚을 수 있을 것같다." }); //호수
        dialogueData.Add(1015, new string[] { "큰 호수이다.", "하지만 호수 안은 텅 비어있다." }); //호수
        dialogueData.Add(1016, new string[] { "귀여운 물고기를 낚았다." }); //호수
        dialogueData.Add(1017, new string[] { "무서운 물고기를 낚았다." }); //호수
        dialogueData.Add(1018, new string[] { "병을 낚았다." }); //호수
        dialogueData.Add(1019, new string[] { "양말을 낚았다." }); //호수
        dialogueData.Add(1020, new string[] { "사탕을 얻었다!" }); //호수
        dialogueData.Add(21, new string[] { "차문이 잠겨있다", "열쇠가 필요하다" }); //빨간 차 
        dialogueData.Add(1021, new string[] { "이 차에 맞지 않은 열쇠다" }); //빨간 차 차키 O
        dialogueData.Add(22, new string[] { "차문이 잠겨있다", "열쇠가 필요하다" }); //초록 차
        dialogueData.Add(1022, new string[] { "이 차에 맞지 않은 열쇠다" }); //초록 차 차키 O
        dialogueData.Add(23, new string[] { "차문이 잠겨있다", "열쇠가 필요하다" }); //흰색 차
        dialogueData.Add(1023, new string[] { "사탕을 얻었다!" }); //흰색 차 차기 O
        dialogueData.Add(24, new string[] { "삽 얻었다", "땅을 팔 수 있을 것 같다." }); //삽

    }
    public string GetDialogue(int id, int dialogueIndex)
    {
        if (dialogueIndex == dialogueData[id].Length) return null; //문자이 끝나면 null return
        else return dialogueData[id][dialogueIndex];
    }
}
