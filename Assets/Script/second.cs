using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class second : MonoBehaviour {
    
    GameObject hour, minute;            //短針、長針
    [SerializeField,Tooltip("制限時間（秒）")]
    float Time_limit;
    float a = 6;                    //角速度
    int i = 1;                          //時間
    bool flag = true;
    string[] scene_name = {"chair","plant","end"};

	void Start () {
        a *= -1;
        hour = GameObject.Find("hour");
        minute = GameObject.Find("minute");
        StartCoroutine(MagicTime());    //最初だけ実行
	}

    void Update()
    {
        if(i >= Time_limit && flag)
        {
            SceneManager.LoadScene("end");
            flag = false; 
         /*   if(GameObject.Find("hensu_kyoyu").GetComponent<hensu>().flag==0)
            {
                GameObject.Find("hensu_kyoyu").GetComponent<hensu>().flag++;
                if(SceneManager.GetActiveScene().name == scene_name[0])
                    SceneManager.LoadScene(scene_name[1]);
                else if(SceneManager.GetActiveScene().name == scene_name[1])
                    SceneManager.LoadScene(scene_name[0]);
            }
            else if(GameObject.Find("hensu_kyoyu").GetComponent<hensu>().flag == 1)
            {
                SceneManager.LoadScene(scene_name[2]);
            }
            {
                
            }*/
        }
    }

    IEnumerator MagicTime() //短針、長針を管理するコルーチン
    {
        minute.transform.Rotate(a , 0, 0); // 1/60回転
        if (i % 6 == 0 && i > 5)                        // 毎6/60回転の時
            hour.transform.Rotate(a / 2f , 0, 0); // 1/120回転
        yield return new WaitForSeconds(1f); //１秒待つ
        i++;
        StartCoroutine(MagicTime()); //次のコルーチンを再帰
    }
}
