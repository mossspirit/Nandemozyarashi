﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_idou : MonoBehaviour {

    const int hundred = 100;
    [Tooltip("移動の速さです。適宜変更をお願い致します。")]
    float speed = 0.01f;
    public float hanni;
    bool flag = false,once_flag = true;
    [System.NonSerialized]
    public bool a_flag = true;
    [SerializeField]
    GameObject obj,camera_pos,con_right;
    
    nekojarasi nekojarashi;
    float  direction_vector_x, direction_vector_z,time;
    Vector3 neko_posi;
    Animator animator;
    string[] anim_name = { "walk", "zyare1", "zyare2", "jump1" };
    SerialMain serial;
    [SerializeField,Tooltip("歩く、待つ、じゃれ１、じゃれ２、ジャンプorじゃれ３")]
    AudioClip[] SEs = new AudioClip[5];

    private bool SE_flag ,ab_flag;
    SE_controller se_con;
    [System.NonSerialized]
    public bool select_flag = false;

    private Vector3 muki_rotate;
    Vector3 _RotAxis = Vector3.up,SYOKI;
    float yziku;
    int i;
    public bool comeback_flag = false;

    private void Awake()
    {
        SYOKI = transform.position;
    }
    void Start ()
    {
        nekojarashi = obj.GetComponent<nekojarasi>();
        animator = GetComponent<Animator>();
        serial = GameObject.Find("SerialMain").GetComponent<SerialMain>();
        se_con = camera_pos.GetComponent<SE_controller>();
	}


    void FixedUpdate()
    {
        for (int i = 0; i < 5; i++) //activeのオブジェクトのSEをSE_conにアタッチ
        {
            se_con.audioClips[i] = SEs[i];
        }
        neko_posi = con_right.transform.position; 
        direction_vector_x = neko_posi.x - transform.position.x;     
        direction_vector_z = neko_posi.z - transform.position.z;

        flag = nekojarashi.idou_flag;//猫じゃらしが動いているかどうか
        //選ばれているか
        if (select_flag)
        {  
            
           // Debug.Log(Mathf.Abs(Mathf.Sqrt(Mathf.Pow((direction_vector_x), 2) + Mathf.Pow((direction_vector_z), 2))) + " " + direction_vector_x + " " + direction_vector_z);
            Rotation(direction_vector_x, direction_vector_z); //回転
            if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((direction_vector_x), 2) + Mathf.Pow((direction_vector_z), 2))) < hanni)
            {
                animator.SetBool(anim_name[0], false);
                SE_flag = se_con.SE_flag;
                Debug.Log(gameObject.name + SE_flag);
                Debug.Log(gameObject.name + once_flag);
                if (once_flag)
                {
                    SE_flag = true;
                    once_flag = false;
                }
                if (SE_flag)
                {
                    Debug.Log(gameObject.name + flag);
                    if (flag)
                    {
                        var i = Random.Range(1, 4);
                        animator.SetTrigger(anim_name[i]);
                        Serial_Shake();
                    }
                }
            }
            else //問題なし
            {
                if (flag)
                {
                    transform.position += transform.forward * Time.deltaTime;
                    animator.SetBool(anim_name[0], true);
                }
                else
                {
                    animator.SetBool(anim_name[0], false);
                }
            }
        }

        //選ばれていない
        else
        {
            if(Mathf.Abs(Mathf.Sqrt(Mathf.Pow((direction_vector_x), 2) + Mathf.Pow((direction_vector_z), 2))) < hanni)
            {
                if (comeback_flag)
                {
                    var x = SYOKI.x - transform.position.x;
                    var z = SYOKI.z - transform.position.z;
                    StartCoroutine(Come_back(x,z));
                }
            }
        }
    }

    private IEnumerator Moving(float dx,float dz)
    {
        flag = nekojarashi.idou_flag;
        if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((direction_vector_x), 2) + Mathf.Pow((direction_vector_z), 2))) >= hanni)
        {
            if (flag)
            {
                transform.position += transform.forward * Time.deltaTime;
                animator.SetBool(anim_name[0],true);
            }
            else
            {
                animator.SetBool(anim_name[0], false);
            }
        }
        else if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((direction_vector_x), 2) + Mathf.Pow((direction_vector_z), 2))) < hanni)
        {
            animator.SetBool(anim_name[0], false);
            SE_flag = se_con.SE_flag;
            if (once_flag)
            {
                SE_flag = true;
                once_flag = false;
            }
            if(SE_flag)
            {
                if (flag)
                {
                    var i = Random.Range(1, 4);
                    animator.SetTrigger(anim_name[i]);
                    Serial_Shake();
                }
            }
        }
        yield return new WaitForSeconds(0.5f);
    }

    void Rotation(float x, float z)
    {
        float rad = Mathf.Atan2(x, z);
        float angle = rad * 180 / Mathf.PI;
        muki_rotate.Set(0f, angle, 0f);
        transform.eulerAngles = muki_rotate;
    }

    private IEnumerator Rotation_comeback()
    {
        float yziku = gameObject.transform.localEulerAngles.y; //?
        //float rad = Mathf.Atan2(dx, dz);
        //float angle = rad * 180 / Mathf.PI;
        i = hundred;
        //float angle_percentage = angle / hundred;
        while (i > 0)
        {
            i--;
            Debug.Log(i);
            yziku += 1.8f;
            muki_rotate.Set(0f, yziku, 0f);
            transform.eulerAngles = muki_rotate;
            yield return new WaitForSeconds(0.01f);
        }
    }
    private IEnumerator Return(float x,float z)
    {
        for (int i = 0; i < 100; i++)
        {

            transform.Translate(x / 100,0f, z / 100);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator Come_back(float x,float z)
    {
        comeback_flag = false;
        StartCoroutine(Rotation_comeback());
        yield return new WaitForSeconds(1f);
        StartCoroutine(Return(x, z));
        yield return new WaitForSeconds(1f);
        //StartCoroutine(Rotation_comeback());
        //yield return new WaitForSeconds(1f);
    }

    void Serial_Shake()
    {
        byte[] data = new byte[1];
        data[0] = 0x61; //aを送信
        serial.Write(data);
    }
     
}
