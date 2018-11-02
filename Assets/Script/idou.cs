using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idou : MonoBehaviour {

    [Tooltip("移動の速さです。適宜変更をお願い致します。")]
    private float speed = 0.01f;
    [SerializeField]
    private float hanni;
    private bool flag = false;
    [System.NonSerialized]
    public bool a_flag = true;
    [SerializeField]
    private GameObject obj; 
    private nekojarasi nekojarashi;
    private float x, z, neko_x, neko_z, direction_vector_x, direction_vector_z;
    private Vector3 neko_posi;
    private Animator animator;
    private string[] anim_name = { "walk","taiki", "zyare1", "zyare2", "jump1" };

    void Start ()
    {
        nekojarashi = obj.GetComponent<nekojarasi>();
        neko_posi = GameObject.Find("[CameraRig]").transform.position;
        animator = GetComponent<Animator>();
	}


    void FixedUpdate()
    {
        x = transform.position.x; //無機物のx       
        z = transform.position.z; //無機物のz       
        neko_x = neko_posi.x;     //猫じゃらしのx       
        neko_z = neko_posi.z;     //猫じゃらしのz       
        direction_vector_x = x - neko_x; // 正の数…第２、３象限　負の数…第１、４象限        
        direction_vector_z = z - neko_z; // 正の数…第３、４象限　負の数…第１、２象限

        flag = nekojarashi.idou_flag;

        StartCoroutine(Moving(direction_vector_x, direction_vector_z));
        /*if(flag && !((direction_vector_x <= hanni) && (direction_vector_x >= -hanni) && (direction_vector_z <= hanni) && (direction_vector_z >= -hanni)))
        {
            Debug.Log(gameObject.name + " " + direction_vector_x + " " + direction_vector_z);
            transform.position += transform.forward * speed;
        }*/
    }

    private IEnumerator Moving(float dx,float dz)
    {
        flag = nekojarashi.idou_flag;

        if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow((direction_vector_x), 2) + Mathf.Pow((direction_vector_z), 2))) >= hanni)
        {
            if (flag)
            {
                //Debug.Log(Mathf.Abs(Mathf.Sqrt(Mathf.Pow((direction_vector_x), 2) + Mathf.Pow((direction_vector_z), 2))) + " " + direction_vector_x + " " + direction_vector_z);
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
            if (flag)
            {
                var i = Random.Range(1, 3);
                animator.SetTrigger(anim_name[i]);
            }
        }
        yield return new WaitForSeconds(0.5f);
    }
}
