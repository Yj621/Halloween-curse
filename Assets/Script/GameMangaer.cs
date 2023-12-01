using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameMangaer : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Text myText; //�ؽ�Ʈ ������Ʈ 
    public GameObject interactionObject; //�÷��̾ ��ȣ�ۿ��� ������Ʈ 
    public GameObject talkPanel; //��ȭâ �г�
    public bool isAction; // ��ȭâ�� ���̰� �Ⱥ��̰� ��Ʈ���ϱ����� ��
    public int dialogueIndex;
    public GameObject note;
    public GameObject shovel;
    public GameObject sheet;

    //��ȣ�ۿ��� ������Ʈ ������ �޾ƿ� �� ��ȭ ���� -> �÷��̾ DialougeManger �޾Ƽ� �����̽��ٷ� ��ȣ�ۿ��ϸ� Action(��ȣ�ۿ� ������Ʈ) ȣ��, �÷��̾�� isAction�� �޾Ƽ� true�϶� ������ ���� 
    public void Action(GameObject interactionObject)
    {

        this.interactionObject = interactionObject;
        ObjectData objectData = interactionObject.GetComponent<ObjectData>();
        Debug.Log("oD" + objectData);
        Debug.Log("oD id" + objectData.id);
        Interaction(objectData.id, objectData.condition);
        talkPanel.SetActive(isAction);
    }
    //��ȣ �ۿ� ��ȭ, ������Ʈ id ������ ��ȭ ���� �����ͼ� ���
    void Interaction(int id, bool condition)
    {
        Debug.Log("Dia");
        if (condition)
        {
            id += 1000;
        }
        Debug.Log(id);
        Debug.Log("���̾Ʒα� �ε���" + dialogueIndex);
        string dialogue = dialogueManager.GetDialogue(id, dialogueIndex);
        //��ȭ�� ������ isAction = false 
        if (dialogue == null)
        {

            isAction = false;
            Debug.Log("�׼� false");
            dialogueIndex = 0;
            if (id == 14) { Destroy(note); }
            if (id == 24) { Destroy(shovel); }
            if (id == 5) { Destroy(sheet); }
            return;
        }
        myText.text = dialogue;
        isAction = true;
        dialogueIndex++; //action Ű�� ���������� �þ�鼭 ���� ��ȭ ��� 


    }
}
