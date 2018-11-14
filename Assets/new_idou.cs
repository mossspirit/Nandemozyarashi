using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_idou : MonoBehaviour {

    int flag = 0;
    bool is_flag = true;
    float new_data, old_data,sum = 0,dx,dz,direction_vector;
    Vector3 muki_rotate;
    nekojarasi _nekojarashi;
    [SerializeField]
    GameObject nekojarashi_obj,cyrinder;
    Animator animator;
    string[] anim_name = { "walk", "zyare1", "zyare2", "jump1" },paramert = { "oko","bikkuri","hatena"};
    Particle particle;
    new_select new_Select;
    public bool erabareteru_flag = false;
    [SerializeField]
    float time = 100;

    void Start () {
        animator = GetComponent<Animator>();
        _nekojarashi = nekojarashi_obj.GetComponent<nekojarasi>();
        dx = nekojarashi_obj.transform.position.x - transform.position.x;
        dz = nekojarashi_obj.transform.position.z - transform.position.z;
        StartCoroutine(Rot(dx, dz));
        direction_vector = Mathf.Abs(Mathf.Sqrt(Mathf.Pow((dx), 2) + Mathf.Pow((dz), 2)) - 1f) / 3; //　オブジェクトの１メートル範囲までの合成ベクトル / 3
        particle = GetComponent<Particle>();
        new_Select = cyrinder.GetComponent<new_select>();
    }
	
	// Update is called once per frame
	void Update () {
        if (erabareteru_flag)
        {
            if (flag == 0 && is_flag)
            {
                is_flag = false;
                StartCoroutine(Huri_shori());
            }
            else if (flag == 1 && is_flag)
            {
                is_flag = false;
                StartCoroutine(Huri_shori());
            }
            else if (flag == 2 && is_flag)
            {
                is_flag = false;
                StartCoroutine(Huri_shori());
            }
            else if (flag == 3 && is_flag)
            {
                //syoumetu
                new_Select.doubutsu_box_enable(true);
            }
        }
    }

    IEnumerator Huri_shori()
    {
        int j = Random.Range(1, 4);
        string _parameta, sum_para;
        if(j == 1)
        {
            _parameta = paramert[j - 1];
            particle.Heart();
        }
        else if (j == 2)
        {
            _parameta = paramert[j - 1];
            particle.Bikkuri();
        }
        else
        {
            _parameta = paramert[j - 1];
            particle.Syun();
        }
        animator.SetTrigger(anim_name[j]);

        for(int i = 0;i < 150; i++)
        {
            new_data = _nekojarashi.new_data;
            old_data = _nekojarashi.old_data;
            sum +=_nekojarashi.Hantei(new_data, old_data);
            yield return new WaitForSeconds(0.015f);
        }

        if(sum < 200)
        {
            sum_para = "oko";
        }
        else if(sum >= 200 && sum <= 10000)
        {
            sum_para = "bikkuri";
        }
        else
        {
            sum_para = "hatena";
        }

        if(_parameta == sum_para)
        {
            StartCoroutine(Move(direction_vector));
        }
        else
        {
            particle.Syun();
            is_flag = true;
        }
    }

    IEnumerator Rot(float x, float z)
    {
        float yziku = gameObject.transform.localEulerAngles.y; //?
        float rad = Mathf.Atan2(x, z);
        float angle = rad * 180 / Mathf.PI / 100;
        int i = 100;
        while (i > 0)
        {
            i--;

            //yziku += angle_percentage;
            yziku += angle;
            muki_rotate.Set(0f, yziku, 0f);
            transform.eulerAngles = muki_rotate;
            yield return new WaitForSeconds(0.01f);
        }
    }
    
    IEnumerator Move(float dire_vector)
    {
        for(int i = 0;i < time; i++)
        {
            Debug.Log(i);
            transform.position += transform.forward * direction_vector / time;
            yield return new WaitForSeconds(time / 10000);
        }
        is_flag = true;
        flag++;
    }
}
