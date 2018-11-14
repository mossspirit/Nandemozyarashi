using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class nekojarasi : MonoBehaviour
{
    /// <summary>    
    /// ねこじゃらしの移動量をフレーム単位で算出してオブジェクトの移動を促す    
    /// 前フレームと今フレームを絶対値で減算し、その値が一定数（sa_hensu）以上であれば    
    /// 猫じゃらしの対象物がこっちに向かってくる（Hanteiメソッドで定義、実装）    
    /// </summary>   

    [System.NonSerialized]
    public float new_data = 0, old_data = 0;

    float c = 0;
    private int i;
    private bool rotation_flag,animation_flag;
    [SerializeField]
    private float sa_hensu = 100f;

    [System.NonSerialized]
    public bool nekojarashi_flag = false;
    [System.NonSerialized]
    public bool idou_flag = false;
    private int flag;
    [SerializeField]
    private GameObject doubutsu;
    private GameObject _child;

     void Start()
    {
        _child = GameObject.Find("Raytaisho");
    }
    void FixedUpdate()
    {
        c++;
        if (c > 2)
        {
            c = 0;
            flag = 0;
        }
        else if (c % 1 == 0)
        {
            old_data = transform.eulerAngles.y;
            flag++;
        }
        new_data = old_data;
    }


    public float Hantei(float new_data, float old_data)
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

            if (result > 1000 && result < 10000) Debug.Log("a");
            else if (result > 10000) Debug.Log("b");

           return result;
        }
        else if (abs_new_data <= abs_old_data)
        {
            if (abs_new_data < 0) abs_new_data *= -1;
            if (abs_old_data > 0) abs_old_data *= -1;
            result = abs_new_data + abs_old_data;
            result *= 100;
            result = System.Math.Abs(result);

            if (result > 1000 && result < 10000) Debug.Log("a");
            else if (result > 10000) Debug.Log("b");
            return result;
        }
        return 0;
    }
}
