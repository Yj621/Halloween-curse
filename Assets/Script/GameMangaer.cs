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

    public bool isKey = false;
    public bool isCarKey = false;
    public bool isRod = false;
    public bool isCandy1 = false;
    public bool isCandy2 = false;
    bool statueInteraction = false; //�ϴ� 

    //��ȣ�ۿ��� ������Ʈ ������ �޾ƿ� �� ��ȭ ���� -> �÷��̾ DialougeManger �޾Ƽ� �����̽��ٷ� ��ȣ�ۿ��ϸ� Action(��ȣ�ۿ� ������Ʈ) ȣ��, �÷��̾�� isAction�� �޾Ƽ� true�϶� ������ ���� 
    public void Action(GameObject interactionObject)
    {
        this.interactionObject = interactionObject;
        ObjectData objectData = interactionObject.GetComponent<ObjectData>();
        Interaction(objectData.id);
        
        talkPanel.SetActive(isAction);
    }
    //��ȣ �ۿ� ��ȭ, ������Ʈ id ������ ��ȭ ���� �����ͼ� ���
    void Interaction(int id)
    {
        string dialogue = dialogueManager.GetDialogue(id, dialogueIndex);
        //��ȭ�� ������ isAction = false 
        if (dialogue == null)
        {
            isAction = false;
            return;
        }
        myText.text = dialogue;
        isAction = true;
        dialogueIndex++; //action Ű�� ���������� �þ�鼭 ���� ��ȭ ��� 
    }
}
