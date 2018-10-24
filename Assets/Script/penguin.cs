using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penguin : MonoBehaviour {
    /// <summary>
    /// 基本的にidou_flagで制御
    /// idou_flagをずっとtrueにしてると二次関数的な移動を行う
    /// 10/24現在のセッティングのままでは回転が終わったら移動となっている
    /// </summary>
    private GameObject nekojarasi;
    private Vector3 neko_posi,nlz,posi,pengin_rotate,start_vector;
    private float x, z, neko_x, neko_z,direction_vector_x,direction_vector_z;
    [SerializeField]
    private float speed = 0.1f;
    private bool flag = true, isgrand = true,idouflag = false;
    private IEnumerator Enumerable;
    private int a = 1;

    void Awake()
    {
        nekojarasi = GameObject.Find("nekojarashi");
        neko_posi = nekojarasi.transform.position; //ねこじゃらしの位置
        //b = GameObject.Find("nekojarashi1_set").GetComponent<nekojarasi>().flag; //ねこじゃらしが沢山ふられたかどうか
    }


    void Update()
    {
        if (isgrand) //地面に接しているか
        {
            moving();
        }
    /*    if (!isgrand && abflag)
        {
            abflag = false;
            StartCoroutine("Wait2");
        }*/
    }

    //猫じゃらしがある方向への移動
    public void moving()
    {
        x = transform.position.x; //無機物のx
        z = transform.position.z; //無機物のz
        neko_x = neko_posi.x;     //猫じゃらしのx
        neko_z = neko_posi.z;     //猫じゃらしのz
        direction_vector_x = x - neko_x; // 正の数…第２、３象限　負の数…第１、４象限
        direction_vector_z = z - neko_z; // 正の数…第３、４象限　負の数…第１、２象限

        posi.Set(0, 0, 1);
        //移動する方向を向く(回転する)
        if(flag)
        {
            Enumerable = Rotation(direction_vector_x, direction_vector_z);
            StartCoroutine(Enumerable);
            flag = false;
        }

        if(idouflag)
        {
            nlz = posi.normalized;
            transform.Translate(nlz * speed);
            if ((direction_vector_x <= 0.1f) && (direction_vector_x >= -0.1f) && (direction_vector_z <= 0.1f) && (direction_vector_z >= -0.1f))
            {
                Debug.Log("a");
                idouflag = false;
            }
        }
    }
    //回転
    //段階に分けて回転させたかったのでコルーチンで制御
    private IEnumerator Rotation(float dx,float dz)
    {
        dx *= -1;
        dz *= -1;
        Debug.Log("a");
        float yziku = gameObject.transform.localEulerAngles.y * -1;
        float rad = Mathf.Atan2(dx, dz);
        float angle = rad * 180 / Mathf.PI;
        float angle_percentage = angle / 100;
        Debug.Log(angle);
        while(!(gameObject.transform.localEulerAngles.y >= angle)) //
        {
            yziku += angle_percentage;
            pengin_rotate.Set(0f, yziku, 0f);
            transform.eulerAngles = pengin_rotate;
            yield return new WaitForSeconds(0.01f);
        }
        idouflag = true;
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane001" && a == 1)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            isgrand = true;
            a++;
        }
        else if(collision.gameObject.name == "Plane001" && a >= 2)
        {
            jumpflag = true;
        }
    }*/
    IEnumerator Wait1()
    {
        yield return new WaitForSeconds(0.3f);
    }
}
