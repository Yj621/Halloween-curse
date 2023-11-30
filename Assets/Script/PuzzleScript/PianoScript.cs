using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PianoScript : MonoBehaviour
{
    public GameObject sheet;
    //변수 선언
    public GameObject imgpiano;
    public GameObject imgpiano2;
    public List<int> pianoarr;    
    public bool play = false;
    public bool sheetOn = false;
    
    //오디오 관련 변수 선언
    public AudioSource audioplayer;
    public AudioClip[] pianoclip;
    

    //이미지 변수 및 오디오 포맷
    void Start()
    {
        pianoarr = new List<int>();
        imgpiano.SetActive(false);
        imgpiano2.SetActive(false);
        sheet.SetActive(false);

        audioplayer = GetComponent<AudioSource>();
    }

    //피아노 상호작용시 작동하는 스크립트
    public void piano()
    {
        imgpiano.SetActive(true);
        imgpiano2.SetActive(true);
        
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
                imgpiano.SetActive(false);
                imgpiano2.SetActive(false);
                play = false;
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
                Item.piece = true;
                imgpiano.SetActive(false);
            }
            pianoarr.Clear();
            Debug.Log("good");
        }
    }

    public void SheetActive()
    {
        sheet.SetActive(true);
        sheetOn = true;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2) && Item.sheet)
        {
            play = true;
        }
        if (play)
        {
            piano();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && sheetOn)
        {
            sheet.SetActive(false);
            sheetOn = false;
        }
    }
}
