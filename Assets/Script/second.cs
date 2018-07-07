using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class second : MonoBehaviour {
    
    GameObject hour, minute;            //短針、長針
    float a = -1.5f;                    //角速度
    int i = 1;                          //時間
    public float hands_speed;           //針の速さ(確認用)。これがないと今回の条件を満たす速さとなる

	void Start () {
        hour = GameObject.Find("hour");
        minute = GameObject.Find("minute");
        StartCoroutine(MagicTime());    //最初だけ実行
	}

    IEnumerator MagicTime() //短針、長針を管理するコルーチン
    {
        minute.transform.Rotate(a * hands_speed, 0, 0); // 1/60回転
        if (i % 6 == 0 && i > 5)                        // 毎6/60回転の時
            hour.transform.Rotate(a / 2f * hands_speed, 0, 0); // 1/120回転
        yield return new WaitForSeconds(1f); //１秒待つ
        i++;
        StartCoroutine(MagicTime()); //次のコルーチンを再帰
    }
}
