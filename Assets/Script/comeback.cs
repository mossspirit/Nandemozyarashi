using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comeback : MonoBehaviour {

	float x,z,neko_x,neko_z,direction_vector_x,direction_vector_z,hanni;
	Vector3 vector,This_rotation,neko_posi;
	const int speed = 100;
	int i,flag = 0;
	Moving_idou Idou;
	GameObject nekozyarashi;
	bool mov_flag;

	void Start () {
		mov_flag =GetComponent<Moving_idou>().select_flag = false;
		mov_flag = false;
		vector = transform.position;
		hanni = GetComponent<Moving_idou>().hanni;
		neko_posi = GameObject.Find("nekojarashi").transform.position;
        Debug.Log("comeback");
	}
	
	void FixedUpdate () {
		if(flag == 0) //回転（後ろを向く）
		{
			x = transform.position.x; //無機物のx
    	    z = transform.position.z; //無機物のz
        	neko_x = vector.x;     //元いた場所のx
    	    neko_z = vector.z;     //元いた場所のz
        	direction_vector_x = neko_x - x; // 正の数…第1、4象限　負の数…第2、3象限
        	direction_vector_z = neko_z - z; // 正の数…第1、2象限　負の数…第3、4象限
			StartCoroutine(Rotation(direction_vector_x,direction_vector_z));
		}
		else if(flag == 1) //移動（元いた場所に帰る）
		{
			if(Mathf.Abs(Mathf.Sqrt(Mathf.Pow((direction_vector_x), 2) + Mathf.Pow((direction_vector_z), 2))) >= hanni)
            	transform.position += transform.forward * Time.deltaTime;
			else
				flag++;
		}
		else if(flag == 2) //回転（猫じゃらしの方を向く）
		{
			x = transform.position.x; //無機物のx
    	    z = transform.position.z; //無機物のz
			neko_x = neko_posi.x;     //猫じゃらしのx
    	    neko_z = neko_posi.z;     //猫じゃらしのz
        	direction_vector_x = neko_x - x; // 正の数…第1、4象限　負の数…第2、3象限
        	direction_vector_z = neko_z - z; // 正の数…第1、2象限　負の数…第3、4象限
			StartCoroutine(Rotation(direction_vector_x,direction_vector_z));

		}
	}

	private IEnumerator Rotation(float dx,float dz){
		float yziku = gameObject.transform.localEulerAngles.y; //?
        float rad = Mathf.Atan2(dx, dz);
        float angle = rad * 180 / Mathf.PI;
		float angle_percentage = angle / (float)speed;
		i = speed;
		while(i >= 0){
			i--;
			yziku += angle_percentage;
            This_rotation.Set(0f, yziku, 0f);
            transform.eulerAngles = This_rotation;
            yield return new WaitForSeconds(0.01f);
		}
		if(flag == 0) flag++;
		else if(flag == 2) Destroy(this);
	}
}
