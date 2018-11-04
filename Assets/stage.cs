using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage : MonoBehaviour {

	private string[] name = { "danbo", "plant", "soccerball", "chair" };
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Z))
            SceneManager.LoadScene(name[0]);
        else if (Input.GetKeyDown(KeyCode.X))
            SceneManager.LoadScene(name[1]);
        else if (Input.GetKeyDown(KeyCode.C))
            SceneManager.LoadScene(name[2]);
        else if (Input.GetKeyDown(KeyCode.V))
            SceneManager.LoadScene(name[3]);
    }
}
