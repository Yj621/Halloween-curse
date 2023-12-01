using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockScript : MonoBehaviour
{
    public Button[] buttons; // 8개의 버튼 배열
    public int[] correctButtons; // 정답 버튼의 인덱스 배열
    private List<int> pressedButtons; // 눌린 버튼 인덱스를 저장하는 리스트
    public GameObject key;
    public Button checkButton; // Check 버튼
    public GameObject drawerUI;
    public GameObject lockUI;

    public bool isPassWordCorrect = false;

    // 버튼의 원래 스프라이트 이미지 배열
    private Sprite[] originalSprites;

    // 버튼의 눌린 스프라이트 이미지 배열
    public Sprite pressedSprite;

    void Start()
    {
        drawerUI.SetActive(false);
        lockUI.SetActive(false);
        key.SetActive(false);
        pressedButtons = new List<int>();

        // 각 버튼의 원래 스프라이트 이미지 저장
        originalSprites = new Sprite[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            originalSprites[i] = buttons[i].image.sprite;
        }

        // 각 버튼에 클릭 이벤트 추가
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i; // 이벤트 핸들러 내에서 사용하기 위해 인덱스 저장
            buttons[i].onClick.AddListener(() => ButtonClicked(buttonIndex));
        }

        // Check 버튼에 클릭 이벤트 추가
        checkButton.onClick.AddListener(() => CheckButtonClicked());
        checkButton.interactable = false; // 초기에 Check 버튼 비활성화
    }

    void Update()
    {
        if (Item.isKey)
        {
            key.SetActive(true);
        }
    }

    void ButtonClicked(int buttonIndex)
    {
        if (!pressedButtons.Contains(buttonIndex))
        {
            pressedButtons.Add(buttonIndex);

            // 버튼의 스프라이트 이미지 변경
            buttons[buttonIndex].image.sprite = pressedSprite;

            Debug.Log("press button value" + pressedButtons[0]);

            CheckPassWord(pressedButtons);
        }
        else
        {
            pressedButtons.Remove(buttonIndex);

            // 버튼의 스프라이트 이미지 원래대로 변경
            buttons[buttonIndex].image.sprite = originalSprites[buttonIndex];
            CheckPassWord(pressedButtons);

            if (pressedButtons.Count < correctButtons.Length)
            {
                checkButton.interactable = false; // Check 버튼 비활성화
            }
        }
    }

    void CheckButtonClicked()
    {
        // 정답 버튼을 눌렀는지 확인
        bool isCorrect = true;
        for (int i = 0; i < correctButtons.Length; i++)
        {
            if (!pressedButtons.Contains(correctButtons[i]))
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            Debug.Log("굳");
            drawerUI.SetActive(true);
            lockUI.SetActive(false);
        }
        else
        {
            Debug.Log("틀렸습니다.");
        }
    }
    public void LockActive()
    {
        lockUI.SetActive(true);
    }

    public void Key()
    {
        key.SetActive(true);
        drawerUI.SetActive(false);
        gameObject.SetActive(false);
    }

    public void CheckPassWord(List<int> pressedButtons)
    {
        if (pressedButtons.Count == correctButtons.Length)
        {
            pressedButtons.Sort();
            for (int i = 0; i < 3; i++)
            {
                if (pressedButtons[i] == correctButtons[i])
                {
                    if (i == 2)
                    {
                        checkButton.interactable = true; // Check 버튼 활성화
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}
