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
        dialogueData.Add(2, new string[] { "�̰��� ���������Դϴ�." }); //��������
        dialogueData.Add(3, new string[] { "�̰��� TV �Դϴ�." }); //TV
        //dialogueData.Add(1003, new string[] { "�̰���, TV �ƴմϴ�" }); //TV
        //dialogueData.Add(10, new string[] { "�Ͼ�����", "��Ű�� ������ �� �� ������ ����" }); //�Ͼ���
        //dialogueData.Add(1010, new string[] { "���� �ϳ� �ٶǴ���" }); //���� ���� �� �Ͼ���
        dialogueData.Add(5, new string[] { "�̰��� �Ǻ��Դϴ�." }); //�Ǻ�
        dialogueData.Add(6, new string[] { "�̰��� �����Դϴ�." }); //����
        dialogueData.Add(7, new string[] { "�̰��� �ǾƳ��Դϴ�." }); //�ǾƳ�
    }
    public string GetDialogue(int id, int dialogueIndex)
    {
        if (dialogueIndex == dialogueData[id].Length) return null; //������ ������ null return
        else return dialogueData[id][dialogueIndex];
    }
}
