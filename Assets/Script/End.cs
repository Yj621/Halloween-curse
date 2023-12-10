using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public float displayImageDuration = 5f;
    public CanvasGroup ending;
    public float fadeDuration = 5f;
    float m_Timer;

    void Start()
    {
        
    }
    
    void Update()
    {            
        EndLevel(ending, true);
    }
    
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {            
        m_Timer += Time.deltaTime;
        
        ending.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration + 7f)
        {
            SceneManager.LoadScene(0);
        }
    }
}
