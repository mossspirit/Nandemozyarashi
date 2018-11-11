using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour {

    private float x, z, neko_x, neko_z, direction_vector_x, direction_vector_z;
    public Transform neko_posi;
    private Vector3 muki_rotate;
    Vector3 _RotAxis = Vector3.up;

    void FixedUpdate ()
    {
        x = transform.position.x; //無機物のx
        z = transform.position.z; //無機物のz
        neko_x = neko_posi.position.x;     //猫じゃらしのx
        neko_z = neko_posi.position.z;     //猫じゃらしのz
        direction_vector_x = neko_x - x; // 正の数…第1、4象限　負の数…第2、3象限
        direction_vector_z = neko_z - z; // 正の数…第1、2象限　負の数…第3、4象限
        /*
        if (direction_vector_x > 0)
        {
            if (direction_vector_z > 0)
                Debug.Log(gameObject.name + "第1象限" + direction_vector_x+"  " + direction_vector_z);
            else
                Debug.Log(gameObject.name + "第4象限" + direction_vector_x + "  " + direction_vector_z);
        }
        else if (direction_vector_x < 0)
        {
            if (direction_vector_z > 0)
                Debug.Log(gameObject.name + "第2象限" + direction_vector_x + "  " + direction_vector_z);
            else
                Debug.Log(gameObject.name + "第3象限" + direction_vector_x + "  " + direction_vector_z);
        }
        else
            Debug.Log("?");
            */
        float yziku = gameObject.transform.localEulerAngles.y; //?
        float rad = Mathf.Atan2(direction_vector_x, direction_vector_z);
        float angle = rad * 180 / Mathf.PI;
        yziku += angle;
        muki_rotate.Set(0f, angle, 0f);
        transform.eulerAngles = muki_rotate;
    }
}
