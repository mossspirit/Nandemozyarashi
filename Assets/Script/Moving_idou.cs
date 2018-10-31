using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Moving_idou: MonoBehaviour {

    /// <summary>
    /// 基本的にidou_flagで制御     
    /// idou_flagをずっとtrueにしてると二次関数的な移動を行う    
    /// 10/24現在のセッティングのままでは回転が終わったら移動となっている    
    /// </summary>
    [SerializeField] 
    private GameObject nekojarasi;   
    private Vector3 neko_posi,nlz,posi,pengin_rotate,start_vector;    
    private float x, z, neko_x, neko_z,direction_vector_x,direction_vector_z;   
    [SerializeField] 
    private float speed = 0.1f;   
    private bool flag = true, isgrand = true,idouflag = false;    
    private IEnumerator Enumerable;    private int a = 1;   
    
    void Awake()   {              
        neko_posi = nekojarasi.transform.position; //ねこじゃらしの位置
        }   
        
    void Update()    {       
        x = transform.position.x; //無機物のx       
        z = transform.position.z; //無機物のz       
        neko_x = neko_posi.x;     //猫じゃらしのx       
        neko_z = neko_posi.z;     //猫じゃらしのz       
        direction_vector_x = x - neko_x; // 正の数…第２、３象限　負の数…第１、４象限        
        direction_vector_z = z - neko_z; // 正の数…第３、４象限　負の数…第１、２象限       
        moving();   
    }
        //猫じゃらしがある方向への移動  
    public void moving()   {      
        nlz = posi.normalized;       
        transform.Translate(nlz * speed);        
        posi.Set(0, 0, 1);       //移動する方向を向く(回転する)      
        if(idouflag)       {         
            nlz = posi.normalized;           
            transform.Translate(nlz * speed);            
            if ((direction_vector_x <= 0.1f) && (direction_vector_x >= -0.1f) && (direction_vector_z <= 0.1f) && (direction_vector_z >= -0.1f)){               
                Debug.Log("a");               
                idouflag = false;           
            }      
        }   
    }  
}