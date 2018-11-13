﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class second : MonoBehaviour {
    
    GameObject hour, minute;            //短針、長針
    [SerializeField,Tooltip("制限時間（秒）")]
    float Time_limit;
    float a = 6;                    //角速度
    int i = 1;                          //時間
    bool flag = true,audioFlag = true;
    [SerializeField]
    private CameraFader _cameraFader = null;
    AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioClips = new AudioClip[2];

    void Start () {
        audioSource = GetComponent<AudioSource>();
        a *= -1;
        hour = GameObject.Find("hour");
        minute = GameObject.Find("minute");
        StartCoroutine(MagicTime());    //最初だけ実行
	}

    void Update()
    {
        if(i >= Time_limit - 10f && audioFlag){
            audioFlag = false;
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
        if(i >= Time_limit && flag)
        {
            StartCoroutine(Load_end());
            flag = false; 
         /*   if(GameObject.Find("hensu_kyoyu").GetComponent<hensu>().flag==0)
            {
                GameObject.Find("hensu_kyoyu").GetComponent<hensu>().flag++;
                if(SceneManager.GetActiveScene().name == scene_name[0])
                    SceneManager.LoadScene(scene_name[1]);
                else if(SceneManager.GetActiveScene().name == scene_name[1])
                    SceneManager.LoadScene(scene_name[0]);
            }
            else if(GameObject.Find("hensu_kyoyu").GetComponent<hensu>().flag == 1)
            {
                SceneManager.LoadScene(scene_name[2]);
            }
            {
                
            }*/
        }
    }

    IEnumerator MagicTime() //短針、長針を管理するコルーチン
    {
        minute.transform.Rotate(a , 0, 0); // 1/60回転
        if (i % 6 == 0 && i > 5)                        // 毎6/60回転の時
            hour.transform.Rotate(a / 2f , 0, 0); // 1/120回転
        yield return new WaitForSeconds(1f); //１秒待つ
        i++;
        StartCoroutine(MagicTime()); //次のコルーチンを再帰
    }

    IEnumerator Load_end()
    {
        var time = 5f;
        _cameraFader.FadeOut(duration: time);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("end");
    }
}
