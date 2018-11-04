using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Moving_idou: MonoBehaviour {

    [SerializeField] 
    private GameObject nekojarasi;   
    private Vector3 neko_posi,nlz,posi,pengin_rotate,start_vector;    
    private float x, z, neko_x, neko_z,direction_vector_x,direction_vector_z;   
    [SerializeField] 
    private float speed = 0.05f;
    [System.NonSerialized]
    public bool flag = false;    
    private IEnumerator Enumerable;
    private int a = 1;
    private bool z_falg = true;
    
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
        Debug.Log(direction_vector_x);
        Debug.Log(direction_vector_z);
        if((direction_vector_x <= 1f) && (direction_vector_x >= -1f) && (direction_vector_z <= 1f) && (direction_vector_z >= -1f))
        {
            z_falg = false;
        }
        else if(!((direction_vector_x <= 1f) && (direction_vector_x >= -1f) && (direction_vector_z <= 1f) && (direction_vector_z >= -1f)) && flag && z_falg)
        {
            transform.position -= transform.forward * speed;
        }
    }
}