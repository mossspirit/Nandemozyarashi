using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class nekojarasi : MonoBehaviour {
    /// <summary>    
    /// ねこじゃらしの移動量をフレーム単位で算出してオブジェクトの移動を促す    
    /// 前フレームと今フレームを絶対値で減算し、その値が一定数（sa_hensu）以上であれば    
    /// 猫じゃらしの対象物がこっちに向かってくる（Hanteiメソッドで定義、実装）    
    /// </summary>   
    /// 
    private float new_data = 0,old_data = 0,c = 0;
    private int i;
    private bool rotation_flag; 
    [SerializeField]
    private float sa_hensu = 100f;   
    [SerializeField,TooltipAttribute("対象のスクリプトを消すか消さないかのためのオブジェクト変数")]
    private GameObject[] objects;
    private bool[] Moving_idou_flag,Rotation_kaiten_flag;
    private Moving_idou[] moving_Idou;
    private Rotation_kaiten[] rotation_Kaiten;
    [System.NonSerialized]
    public bool nekojarashi_flag = false;  
    [System.NonSerialized]  
    public int flag;

    void Start () {     
        new_data = transform.eulerAngles.y;  
        for(i = 0;i <= objects.Length;i++)
        {
            moving_Idou[i] = objects[i].GetComponent<Moving_idou>();     
            Moving_idou_flag[i] = moving_Idou[i].enabled;       
            Moving_idou_flag[i] = false;

            rotation_Kaiten[i] = objects[i].GetComponent<Rotation_kaiten>();
            Rotation_kaiten_flag[i] = rotation_Kaiten[i].enabled;
            Rotation_kaiten_flag[i] = false;
        }     
    }    
    void FixedUpdate () {        
        c++; 
        if(c >= 120) c = 0;      
        else if (c % 7 == 0) {            
            old_data = transform.eulerAngles.y;           
            flag++;
            rotation_flag = rotation_Kaiten[0].flag;   
            if (Hantei(new_data, old_data) && flag >= 10) {
                if(rotation_flag){
                    for(i = 0;i<=Rotation_kaiten_flag.Length;i++){
                    Rotation_kaiten_flag[i] = true;
                    }
                }
                else
                    for(i = 0;i<=Moving_idou_flag.Length;i++){
                    Moving_idou_flag[i] = true;
                }       
                nekojarashi_flag = true;        
            }          
            else {  
                for(i = 0;i<=Moving_idou_flag.Length;i++){
                    Rotation_kaiten_flag[i] = false;
                    Moving_idou_flag[i] = false;
                }                     
                nekojarashi_flag = false;            
            }      
            new_data = old_data;       
        }
    }  

    public bool Hantei(float new_data,float old_data){
        float result;
        float abs_new_data, abs_old_data;       
        abs_new_data = System.Math.Abs(new_data);        
        abs_old_data = System.Math.Abs(old_data);        
        if (abs_new_data > abs_old_data) {           
            if (abs_new_data < 0) abs_new_data *= -1;           
            if (abs_old_data > 0) abs_old_data *= -1;            
            result = abs_new_data + abs_old_data;            
            result *= 100;
            result = System.Math.Abs(result);           
            //Debug.Log(result);    
            if (result > sa_hensu) return true;        
            else return false;      
        }
        else if (abs_new_data < abs_old_data) {       
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