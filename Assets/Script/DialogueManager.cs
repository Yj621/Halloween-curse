using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //������Ʈ ���̵� ���� ������ ��ȭ ���� ���� ������Ʈ ���̵�� objectData ��ũ��Ʈ���� ���� 
    Dictionary<int, string[]> dialogueData;

    private void Awake()
    {
        dialogueData = new Dictionary<int, string[]>();
        GenerateData();
    }
    void GenerateData()
    {
        dialogueData.Add(1, new string[] { "�׽�Ʈ", "���̾�α�", "�Դϴ�." }); // id, ��ȭ ����
    }
    public string GetDialogue(int id, int dialogueIndex)
    {
        if (dialogueIndex == dialogueData[id].Length) return null; //������ ������ null return
        else return dialogueData[id][dialogueIndex];
    }
}
