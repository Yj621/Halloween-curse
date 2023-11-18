using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PianoScript : MonoBehaviour
{
    //변수 선언
    public GameObject imgpiano;
    public bool havesheet;
    public bool havepiece;
    public List<int> pianoarr;
    bool imgstatus = true;
    

    public AudioSource audioplayer;
    public AudioClip[] pianoclip;
    

    //게임 시작 시 기본 설정.
    void Start()
    {
        havesheet = false;
        havepiece = false;
        pianoarr = new List<int>();
        imgpiano.SetActive(false);
        

        audioplayer = GetComponent<AudioSource>();
    }

    //피아노 상호작용시 작동하는 스크립트
    void piano()
    {
        imgpiano.SetActive(imgstatus);

        int[] pianoanswer = {3,2,1,2,3,3,3};
        int pianoanswercount = 0;
        if (pianoarr.Count < 7)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                audioplayer.clip = pianoclip[0];
                audioplayer.Play();
                pianoarr.Add(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                audioplayer.clip = pianoclip[1];
                audioplayer.Play();
                pianoarr.Add(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                audioplayer.clip = pianoclip[2];
                audioplayer.Play();
                pianoarr.Add(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                audioplayer.clip = pianoclip[3];
                audioplayer.Play();
                pianoarr.Add(4);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                audioplayer.clip = pianoclip[4];
                audioplayer.Play();
                pianoarr.Add(5);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                audioplayer.clip = pianoclip[5];
                audioplayer.Play();
                pianoarr.Add(6);
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                audioplayer.clip = pianoclip[6];
                audioplayer.Play();
                pianoarr.Add(7);
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                audioplayer.clip = pianoclip[7];
                audioplayer.Play();
                pianoarr.Add(8);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                imgstatus = false;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                pianoarr.Clear();
            }
        }
        else
        {
            for (int i = 0; i < pianoarr.Count; i++)
            {
                if (pianoarr[i] != pianoanswer[i])
                {
                    break;
                }
                else 
                {
                    pianoanswercount++;
                }
            }
            if (pianoanswercount == 7)
            {
                havepiece = true;
            }
            pianoarr.Clear();
            Debug.Log("good");
        }
    }

    //그림조각을 얻고 액자와 상호작용 했을 때 실행되는 스크립트
    void frame()
    {

    }

    
    void Update()
    {
        piano();
        
    }
}
