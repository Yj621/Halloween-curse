using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    public GameObject settingPanel;
    bool isPanelOn = false;

    private void Start()
    {
        settingPanel.SetActive(false);
    }
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape) &&isPanelOn)
        {
            settingPanel.SetActive(false);
        }   
    }
    public void SettingPanelTrue()
    {
        settingPanel.SetActive(true);
        isPanelOn=true;
    }
    public void SettingPanelFalse()
    {
        settingPanel.SetActive(false);
        isPanelOn = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
