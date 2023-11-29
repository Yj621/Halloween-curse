using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeState : MonoBehaviour
{    
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Fish1()
    {
        animator.SetBool("fish1", true);
        Invoke("ResetFish1", 2f);
    }

    public void Fish2()
    {
        animator.SetBool("fish2", true);        
        Invoke("ResetFish2", 2f);
    }

    public void Fish3()
    {        
        animator.SetBool("fish3", true);
        Invoke("ResetFish3", 2f);
    }

    public void Sock()
    {        
        animator.SetBool("sock", true);
        Invoke("ResetSock", 2f);
    }

    public void Bottle()
    {        
        animator.SetBool("bottle", true);
        Invoke("ResetBottle", 2f);
    }

    void ResetFish1()
    {
        animator.SetBool("fish1", false);
    }

    void ResetFish2()
    {
        animator.SetBool("fish2", false);
    }

    void ResetFish3()
    {
        animator.SetBool("fish3", false);
    }

    void ResetSock()
    {
        animator.SetBool("sock", false);
    }

    void ResetBottle()
    {
        animator.SetBool("bottle", false);
    }
}
