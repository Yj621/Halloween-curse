using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameMangaer : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Text myText; //텍스트 오브젝트 
    public GameObject interactionObject; //플레이어가 상호작용한 오브젝트 
    public GameObject talkPanel; //대화창 패널
    public bool isAction; // 대화창이 보이고 안보이고를 컨트롤하기위한 값
    public int dialogueIndex;
    public GameObject note;
    public GameObject shovel;
    public GameObject sheet;
    public GameObject xMark;
    public GameObject wheel;
    public GameObject carKey2;
    public GameObject oil;

    //상호작용한 오브젝트 정보를 받아온 뒤 대화 실행 -> 플레이어에 DialougeManger 받아서 스페이스바로 상호작용하면 Action(상호작용 오프젝트) 호출, 플레이어에서 isAction값 받아서 true일때 움직임 막기 
    public void Action(GameObject interactionObject)
    {

        this.interactionObject = interactionObject;
        ObjectData objectData = interactionObject.GetComponent<ObjectData>();
        Debug.Log("oD id" + objectData.id);
        Interaction(objectData.id, objectData.condition);
        talkPanel.SetActive(isAction);
    }
    //상호 작용 대화, 오브젝트 id 값으로 대화 내용 가져와서 출력
    void Interaction(int id, int condition)
    {
        Debug.Log("Dia");
        if (condition == 1)
        {
            id += 1000;
        }
        else if (condition == 2)
        {
            id += 2000;
        }
        Debug.Log(id);
        Debug.Log("다이아로그 인덱스" + dialogueIndex);
        string dialogue = dialogueManager.GetDialogue(id, dialogueIndex);
        //대화가 끝나면 isAction = false 
        if (dialogue == null)
        {

            isAction = false;
            Debug.Log("액션 false");
            dialogueIndex = 0;
            if (id == 14) { Destroy(note); }
            if (id == 24) { Destroy(shovel); }
            if (id == 5) { Destroy(sheet); }
            if (id == 27) { Destroy(xMark); }
            if (id == 29) { Destroy(oil); }
            if (id == 30) { Destroy(wheel); }
            if (id == 31) { Destroy(carKey2); }
            return;
        }
        myText.text = dialogue;
        isAction = true;
        dialogueIndex++; //action 키를 누를때마다 늘어나면서 다음 대화 출력 


    }
}
