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
    }
    public void Fish2()
    {
        animator.SetBool("fish2", true);
    }
    public void Fish3()
    {        
        animator.SetBool("fish3", true); 
    }
    public void Sock()
    {        
        animator.SetBool("sock", true);
    }
    public void Bottle()
    {        
        animator.SetBool("bottle", true);
    }
}
