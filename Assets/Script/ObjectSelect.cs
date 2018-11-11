using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelect : MonoBehaviour {

	string obj_name;
	float time = 0;
	[SerializeField]
	GameObject[] gameObjects = new GameObject[5];
	GameObject old_object;
	bool once_flag = true;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		var counter = 0;
		for(int i = 0;i < 5;i++){
			if(gameObjects[i].GetComponent<Moving_idou>().select_flag)
			counter++;
		}
		if(counter > 1){
			for(int i = 0;i < 5;i++){
				gameObjects[i].GetComponent<Moving_idou>().select_flag = false;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		obj_name = other.name;
	}
    private void OnTriggerStay(Collider other)
    {
        if(other.name == obj_name){
			time += Time.deltaTime;
			if(time >= 1 && once_flag){
				other.GetComponent<Moving_idou>().select_flag = true;
				if(old_object){
					old_object.AddComponent<comeback>();
				}
				old_object = other.gameObject;
				once_flag = false;
			}
		}
    }
	private void OnTriggerExit(Collider other){
		time = 0;
	}
}
