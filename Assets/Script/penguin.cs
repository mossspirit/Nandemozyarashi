using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penguin : MonoBehaviour {

    [SerializeField,Tooltip("ペンギンが追従するオブジェクト")]
    private GameObject nekojarasi;
    private Vector3 neko_posi,nlz,posi,pengin_rotate,start_vector;
    private float x, z, neko_x, neko_z,direction_vector_x,direction_vector_z;
    [SerializeField]
    private float speed = 0.1f,flap = 2f;
    private Rigidbody rb;
    private bool flag = true, isgrand = false,idouflag = false,jumpflag,abflag = true;
    private IEnumerator Enumerable;
    private int a = 1 ,b;

    void Awake()
    {
        neko_posi = nekojarasi.transform.position; //ねこじゃらしの位置
        b = GameObject.Find("nekojarashi1_set").GetComponent<nekojarasi>().flag; //ねこじゃらしが沢山ふられたかどうか
    }


    void Update()
    {
        if (isgrand) //地面に接しているか
        {
            moving();
        }
        if (!isgrand && abflag)
        {
            abflag = false;
            StartCoroutine("Wait2");
        }
    }

    //
    void moving()
    {
        x = transform.position.x;
        z = transform.position.z;
        neko_x = neko_posi.x;
        neko_z = neko_posi.z;
        direction_vector_x = neko_x - x;
        direction_vector_z = neko_z - z;
        posi.Set(0, 0, -1);

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
                jumpflag = true;
            }
        }
        if(jumpflag)
        {
            Jump();
            jumpflag = false; //falseにしないと無限ジャンプする
        }
    }

    private IEnumerator Rotation(float dx,float dz)
    {
        Debug.Log("a");
        dx *= -1;
        dz *= -1;
        float yziku = gameObject.transform.localEulerAngles.y * -1;
        Debug.Log(yziku);
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
    void Jump()
    {
        rb.AddForce(start_vector * 100f * flap);
        start_vector = Vector3.up;
        StartCoroutine("Wait1");
    }
    private void OnCollisionEnter(Collision collision)
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
    }
    IEnumerator Wait1()
    {
        yield return new WaitForSeconds(0.3f);
    }
    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(5f);
        start_vector = Vector3.up + Vector3.back;
        rb = gameObject.GetComponent<Rigidbody>();
        Jump();
    }
}
