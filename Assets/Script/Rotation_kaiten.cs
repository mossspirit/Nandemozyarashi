using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_kaiten : MonoBehaviour {


    /// <summary>
    /// 回転を移動と異なるスクリプトで管理
    /// 移動と回転を同時に行うと二次関数的に挙動を起こす
    /// 基本的に同時に行わずに、回転、移動と動作を行わせる
    /// </summary>

    private float x, z, neko_x, neko_z, direction_vector_x, direction_vector_z;
    private GameObject nekojarashi;
    private Vector3 pengin_rotate,neko_posi;
    [SerializeField,Tooltip("回転の速さを決める係数。speed * 0.01(秒)")]
    private int speed = 100;

	void Start () 
    {
        nekojarashi = GameObject.Find("nekojarashi1");
        neko_posi = nekojarashi.transform.position; //ねこじゃらしの位置
	}
	
	void Update () 
    {
        x = transform.position.x; //無機物のx
        z = transform.position.z; //無機物のz
        neko_x = neko_posi.x;     //猫じゃらしのx
        neko_z = neko_posi.z;     //猫じゃらしのz
        direction_vector_x = x - neko_x; // 正の数…第２、３象限　負の数…第１、４象限
        direction_vector_z = z - neko_z; // 正の数…第３、４象限　負の数…第１、２象限
        Rotation(direction_vector_x, direction_vector_z);
	}

    private IEnumerator Rotation(float dx, float dz)
    {
        float yziku = gameObject.transform.localEulerAngles.y; //?
        float rad = Mathf.Atan2(dx, dz);
        float angle = rad * 180 / Mathf.PI;
        float angle_percentage = angle / (float)speed;
        Debug.Log(angle);
        while (!(gameObject.transform.localEulerAngles.y >= angle)) //
        {
            yziku += angle_percentage;
            pengin_rotate.Set(0f, yziku, 0f);
            transform.eulerAngles = pengin_rotate;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
