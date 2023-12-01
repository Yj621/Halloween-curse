using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public GameObject manualUI;
    SceneManage sceneManage;

    void Start()
    {
        sceneManage = FindObjectOfType<SceneManage>();
        manualUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBtnManualClose();
        }
    }

    public void OnBtnStart()
    {
        sceneManage.Home();
    }
    public void OnBtnManual()
    {
        manualUI.SetActive(true);
    }
    public void OnBtnManualClose()
    {
        manualUI.SetActive(false);
    }
}
