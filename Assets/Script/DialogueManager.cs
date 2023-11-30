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
        dialogueData.Add(0, new string[] { "���� ������ ó�� ���� ����̴�.", "â�ۿ� �Ҷ�������.", "â���� ���� ���ɵ��� ���� �ٴϰ��ִ�.", "���� �̰��� Ż���ؾ��� �� ����." }); // ���� ����
        //dialogueData.Add(1, new string[] { "�׽�Ʈ", "���̾�α�", "�Դϴ�." }); // id, ��ȭ ����
        dialogueData.Add(2, new string[] { "�����Ⱑ �������ִ�." }); //��������
        dialogueData.Add(3, new string[] { "�۵����� �ʴ´�. �������� ����?" }); //TV
        dialogueData.Add(4, new string[] { "���� ����� ��ģ��" }); //�ſ�
        dialogueData.Add(5, new string[] { "�Ǻ��� �����!" }); //�Ǻ�
        dialogueData.Add(6, new string[] { "�̰��� �����Դϴ�." }); //����
        dialogueData.Add(7, new string[] { "�Ǻ��� ������ ���� �� �� �����ٵ�..." }); //�ǾƳ�
        dialogueData.Add(1007, new string[] { "�Ʊ� ���� �Ǻ��� ���� �� �� ���� �� ����." }); //�ǾƳ�, �Ǻ� O
        dialogueData.Add(8, new string[] { "�ƹ��͵� ���� �� ����." }); //ħ��
        dialogueData.Add(9, new string[] { "���� �ؿ��� ������ �����ϴ�." }); //����
        dialogueData.Add(10, new string[] { "���𰡷� �� ����� �Ѵ�." }); //����
        dialogueData.Add(1010, new string[] { "������ �������� �߶���." }); //����, ���� O
        dialogueData.Add(11, new string[] { "���谡 �־�� Ż���� �� ���� �� ����." }); //��
        dialogueData.Add(12, new string[] { "�۵����� �ʴ´�." }); //�ð�
        dialogueData.Add(13, new string[] { "�۵����� �ʴ´�." }); //����������
        //��2
        dialogueData.Add(14, new string[] { "���� �������̴�.", "�������� ���� ���� ���� �� ������ ����." }); //����
        dialogueData.Add(15, new string[] { "ū ȣ���̴�.", "���ô밡 ������ ���� ���� �� ���� �Ͱ���." }); //ȣ��
        dialogueData.Add(1015, new string[] { "ū ȣ���̴�.", "������ ȣ�� ���� �� ����ִ�." }); //ȣ��
        dialogueData.Add(1016, new string[] { "�Ϳ��� ����⸦ ���Ҵ�." }); //ȣ��
        dialogueData.Add(1017, new string[] { "������ ����⸦ ���Ҵ�." }); //ȣ��
        dialogueData.Add(1018, new string[] { "���� ���Ҵ�." }); //ȣ��
        dialogueData.Add(1019, new string[] { "�縻�� ���Ҵ�." }); //ȣ��
        dialogueData.Add(1020, new string[] { "������ �����!" }); //ȣ��
        dialogueData.Add(21, new string[] { "������ ����ִ�", "���谡 �ʿ��ϴ�" }); //���� �� 
        dialogueData.Add(1021, new string[] { "�� ���� ���� ���� �����" }); //���� �� ��Ű O
        dialogueData.Add(22, new string[] { "������ ����ִ�", "���谡 �ʿ��ϴ�" }); //�ʷ� ��
        dialogueData.Add(1022, new string[] { "�� ���� ���� ���� �����" }); //�ʷ� �� ��Ű O
        dialogueData.Add(23, new string[] { "������ ����ִ�", "���谡 �ʿ��ϴ�" }); //��� ��
        dialogueData.Add(1023, new string[] { "������ �����!" }); //��� �� ���� O
        dialogueData.Add(24, new string[] { "�� �����", "���� �� �� ���� �� ����." }); //��

    }
    public string GetDialogue(int id, int dialogueIndex)
    {
        if (dialogueIndex == dialogueData[id].Length) return null; //������ ������ null return
        else return dialogueData[id][dialogueIndex];
    }
}
