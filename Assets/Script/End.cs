using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public float displayImageDuration = 1f;
    public CanvasGroup ending;
    public float fadeDuration = 3f;
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

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            Application.Quit ();
        }
    }
}
