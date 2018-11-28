using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Particle : MonoBehaviour
{

    [SerializeField, Tooltip("ハート、ビックリ、シュン")]
    ParticleSystem[] particle = new ParticleSystem[3];

    /*void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            particle[i].Stop();
        }
    }*/

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Heart();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Bikkuri();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Syun();
        }
    }
    public void Heart()
    {
        particle[0].Play();
        //Debug.Log("a");
        //1500ミリ秒後にLogを出す
        Observable.Timer(TimeSpan.FromMilliseconds(1000))
            .Subscribe(_ => particle[0].Stop());
    }
    public void Bikkuri()
    {
        particle[1].Play();
        //Debug.Log("b");
        //1500ミリ秒後にLogを出す
        Observable.Timer(TimeSpan.FromMilliseconds(1000))
            .Subscribe(_ => particle[1].Stop());
    }
    public void Syun()
    {
        particle[2].Play();
        //Debug.Log("c");
        //1500ミリ秒後にLogを出す
        Observable.Timer(TimeSpan.FromMilliseconds(1000))
            .Subscribe(_ => particle[2].Stop());
    }
}
