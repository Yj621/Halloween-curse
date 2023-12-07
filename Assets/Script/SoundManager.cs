using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource shovelSound;
    public AudioSource itemSound;

    void Start()
    {
        if (shovelSound == null)
        {
            shovelSound = GetComponent<AudioSource>();
        }
        if (itemSound == null)
        {
            itemSound = GetComponent<AudioSource>();
        }        
    }

    public void PlayShovelSound()
    {
        shovelSound.Play();
        Debug.Log("shovel sound");
    }
    public void PlayItemGetSound()
    {
        itemSound.Play();
        Debug.Log("itemSound");
    }
    
}
