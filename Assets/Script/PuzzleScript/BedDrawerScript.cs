using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedDrawerScript : MonoBehaviour
{
    public GameObject bedDrawerUI;
    public GameObject batteryUI;
    public SpriteRenderer orignalImg;
    SoundManager soundManager;

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
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            bedDrawerUI.SetActive(false);
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
    }

    public void ChangeSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = orignalImg.sprite;
    }
}
