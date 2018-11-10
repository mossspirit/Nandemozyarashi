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
    /// 
    private float new_data = 0, old_data = 0, c = 0;
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
        animation_flag = doubutsu.GetComponent<idou>().a_flag;
        c++;
        if (c > 4)
        {
            c = 0;
            flag = 0;
        }
        else if (c % 2 == 0)
        {
            old_data = transform.eulerAngles.y;
            flag++;

            if (Hantei(new_data, old_data) && flag >= 1 || Input.GetKey(KeyCode.Z))
            {
                idou_flag = true;

            }
            else
            {
                idou_flag = false;
            }
        }
        new_data = old_data;
    }


    public bool Hantei(float new_data, float old_data)
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

    void RayTest()
    {
        //Rayの作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
        Ray ray = new Ray(transform.position, _child.transform.position);

        //Rayが当たったオブジェクトの情報を入れる箱
        RaycastHit hit;

        //Rayの飛ばせる距離
        int distance = 10;

        //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　　　　　　↓Rayの色
        Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);

        //もしRayにオブジェクトが衝突したら
        //                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
        if (Physics.Raycast(ray, out hit, distance))
        {
            //Rayが当たったオブジェクトのtagがPlayerだったら
            if (hit.collider.tag == "Player")
                Debug.Log("RayがPlayerに当たった");
        }
    }
}
