﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class nekojarasi : MonoBehaviour {

    /// <summary>
    /// ねこじゃらしの移動量をフレーム単位で算出してオブジェクトの移動を促す
    /// 前フレームと今フレームを絶対値で減算し、その値が一定数（sa_hensu）以上であれば
    /// 猫じゃらしの対象物がこっちに向かってくる（Hanteiメソッドで定義、実装）
    /// </summary>
    /// 
    private float a = 0,b = 0,c = 0;
    [SerializeField]
    private float sa_hensu = 100f;
    [SerializeField]
    private GameObject pengin;
    private bool penguin_flag = false;

    [System.NonSerialized]
    public bool nekojarashi_flag = false;
    [System.NonSerialized]
    public int flag;

    void Start () {
        a = transform.eulerAngles.y;

        pengin.GetComponent<penguin>().enabled = false;
    }

    void FixedUpdate () {
        c++;
        if (c % 7 == 0)
        {
            b = transform.eulerAngles.y;
            Debug.Log(Hantei(a, b));
            flag++;
            if (Hantei(a, b) && flag >= 10)
            {
                pengin.GetComponent<penguin>().enabled = true;
                nekojarashi_flag = true;
            }
            else
            {
                pengin.GetComponent<penguin>().enabled = false;
                nekojarashi_flag = false;
            }
            a = b;
        }
	}

    public bool Hantei(float new_data,float old_data) 
    {
        float result;
        float abs_new_data, abs_old_data;
        abs_new_data = System.Math.Abs(new_data);
        abs_old_data = System.Math.Abs(old_data);
        if (abs_new_data > abs_old_data)
        {
            if (abs_new_data < 0) abs_new_data *= -1;
            if (abs_old_data > 0) abs_old_data *= -1;
            result = abs_new_data + abs_old_data;
            result *= 100;
            result = System.Math.Abs(result);
            //Debug.Log(result);
            if (result > sa_hensu) return true;
            else return false;
        }
        else if (abs_new_data < abs_old_data)
        {
            if (abs_new_data < 0) abs_new_data *= -1;
            if (abs_old_data > 0) abs_old_data *= -1;
            result = abs_new_data + abs_old_data;
            result *= 100;
            result = System.Math.Abs(result);
            //Debug.Log(result);
            if (result > sa_hensu) return true;
            else return false;
        }
        else return false; //値が同じ　＝　動かしていない
    }
}
