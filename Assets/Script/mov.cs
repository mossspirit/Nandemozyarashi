using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour {

    Vector3 old, neko;
    GameObject nekojarashi;

    void Start () {
        nekojarashi = GameObject.Find("nekojarashi");
        old = transform.position;
        neko = nekojarashi.transform.position;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
