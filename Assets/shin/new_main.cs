using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_main : MonoBehaviour {

    int i = 0;
	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] doubutsus = GameObject.FindGameObjectsWithTag("doubutsu");
        foreach(GameObject doubutsu in doubutsus)
        {
            i++;
        }
        Debug.Log(i);
        i = 0;
    }
}
