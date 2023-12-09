using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedDrawerScript : MonoBehaviour
{
    public GameObject bedDrawerUI;
    public GameObject batteryUI;
    public SpriteRenderer orignalImg;
    SoundManager soundManager;

    public Text myText;
    public GameObject imagePanel;
    public GameMangaer gameManager;

    void Start()
    {
        bedDrawerUI.SetActive(false);
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Awake()
    {
        batteryUI.SetActive(false);
    }

    void Update()
    {
        if (Item.isBattery)
        {
            batteryUI.SetActive(true);
        }else{
            batteryUI.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            bedDrawerUI.SetActive(false);
            Player.panelOn = false;
    }

    public void BedDrawer()
    {
        bedDrawerUI.SetActive(true);
    }
    public void Battery()
    {
        Item.isBattery = true;
        soundManager.PlayItemGetSound();
        bedDrawerUI.SetActive(false);

        imagePanel.SetActive(true);
        myText.text = "배터리를 얻었다.";
        gameManager.isAction = true;
    }

    public void ChangeSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = orignalImg.sprite;
        
    }
}
