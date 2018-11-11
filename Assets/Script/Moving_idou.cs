using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_idou : MonoBehaviour {

    [Tooltip("移動の速さです。適宜変更をお願い致します。")]
    float speed = 0.01f;
    public float hanni;
    bool flag = false,once_flag = true;
    [System.NonSerialized]
    public bool a_flag = true;
    [SerializeField]
    GameObject obj,camera_pos,con_right; 
    nekojarasi nekojarashi;
    float x, z, neko_x, neko_z, direction_vector_x, direction_vector_z,time;
    Vector3 neko_posi;
    Animator animator;
    string[] anim_name = { "walk", "zyare1", "zyare2", "jump1" };
    SerialMain serial;
    [SerializeField,Tooltip("歩く、待つ、じゃれ１、じゃれ２、ジャンプorじゃれ３")]
    AudioClip[] SEs = new AudioClip[5];
    [SerializeField,Tooltip("自分以外の動物（無機物）")]
    GameObject[] gameObjects;
    private bool SE_flag ;
    SE_controller se_con;
    [System.NonSerialized]
    public bool select_flag = false;

    void Start ()
    {
        nekojarashi = obj.GetComponent<nekojarasi>();
        animator = GetComponent<Animator>();
        serial = GameObject.Find("SerialMain").GetComponent<SerialMain>();
        se_con = camera_pos.GetComponent<SE_controller>();
	}


    void FixedUpdate()
    {
        neko_posi = con_right.transform.position;

        x = transform.position.x; //無機物のx       
        z = transform.position.z; //無機物のz       
        neko_x = neko_posi.x;     //猫じゃらしのx       
        neko_z = neko_posi.z;     //猫じゃらしのz       
        direction_vector_x = x - neko_x; // 正の数…第２、３象限　負の数…第１、４象限        
        direction_vector_z = z - neko_z; // 正の数…第３、４象限　負の数…第１、２象限
        if(select_flag)StartCoroutine(Moving(direction_vector_x, direction_vector_z));
        for(int i=0;i < 5; i++) //activeのオブジェクトのSEをSE_conにアタッチ
        {
            se_con.audioClips[i] = SEs[i];
        }
    }

    private IEnumerator Moving(float dx,float dz)
    {
        flag = nekojarashi.idou_flag;
        //Debug.Log(Mathf.Abs(Mathf.Sqrt(Mathf.Pow((direction_vector_x), 2) + Mathf.Pow((direction_vector_z), 2))) + " " + direction_vector_x + " " + direction_vector_z);

        if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((direction_vector_x), 2) + Mathf.Pow((direction_vector_z), 2))) >= hanni)
        {
            if (flag)
            {
                transform.position += transform.forward * speed;
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

            Debug.Log(SE_flag);
            if(SE_flag)
            {
                if (flag)
                {
                    var i = Random.Range(1, 4);
                    animator.SetTrigger(anim_name[i]);
                    byte[] data = new byte[1];
                    data[0] = 0x61; //aを送信
                    serial.Write(data);
                }
            }
        }
        yield return new WaitForSeconds(0.5f);
    }

}
