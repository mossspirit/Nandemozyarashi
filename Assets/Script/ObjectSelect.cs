using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSelect : MonoBehaviour {

	string obj_name;
	float time = 0;
	[SerializeField]
	GameObject[] gameObjects = new GameObject[5];
	GameObject old_object;
    bool once_flag = true, null_kaihi_flag = true;
    [SerializeField]
    private CameraFader _cameraFader = null;

    void Start ()
    {
        _cameraFader.FadeIn(duration: 3f);
    }

    // Update is called once per frame
    void Update () 
	{
        if (Input.GetKeyDown(KeyCode.J))
        {
            SteamVR_Fade.Start(Color.white, 1f);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SteamVR_Fade.Start(Color.clear, 1f);
        }
		/*var counter = 0;
		for(int i = 0;i < 5;i++){
			if(gameObjects[i].GetComponent<Moving_idou>().select_flag)
			counter++;
		}
		if(counter > 1){
			for(int i = 0;i < 5;i++){
				gameObjects[i].GetComponent<Moving_idou>().select_flag = false;
			}
		}*/
	}

    /*private void OnTriggerEnter(Collider other)
	{
		obj_name = other.name;
        once_flag = true;
        Debug.Log(other.name);
	}*/

    GameObject child_obj;
    Image UIobj;
    private void OnTriggerStay(Collider other)
    {
        time += Time.deltaTime;
        if (once_flag)
        {
			if(old_object != other.gameObject){
			foreach (Transform child in other.gameObject.transform)
            {
                if(child.name == "HPUI")
                {
                    child.gameObject.SetActive(true);
                    child_obj = child.gameObject;
                }
            }
            foreach(Transform child in child_obj.transform)
            {
                if(child.name == "bluecycle")
                {
                    UIobj = child.GetComponent<Image>();
                }
			}
            UIobj.fillAmount = 1 - time / 3;
			}
            if (time >= 3)
            {
                UIobj.fillAmount = 1f;
                child_obj.SetActive(false);
                once_flag = false;
                //Debug.Log(obj_name);
                other.GetComponent<Moving_idou>().select_flag = true;
                if (old_object != other.gameObject && !null_kaihi_flag)
                {
                    Debug.Log("a");
                    old_object.GetComponent<Moving_idou>().select_flag = false;
                    old_object.GetComponent<Moving_idou>().comeback_flag = true;
                }
                old_object = other.gameObject;
                null_kaihi_flag = false;
            }

        }
    }
	private void OnTriggerExit(Collider other){
		time = 0;
        once_flag = true;
    }
}
