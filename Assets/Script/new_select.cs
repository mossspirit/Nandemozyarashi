using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class new_select : MonoBehaviour {

    string obj_name;
    float time = 0;
    GameObject old_object;
    bool once_flag = true;
    [SerializeField]
    private CameraFader _cameraFader = null;

    void Start () {

    }

    GameObject child_obj;
    Image UIobj;
    private void OnTriggerStay(Collider other)
    {
        time += Time.deltaTime;
        if (once_flag)
        {
            if (old_object != other.gameObject)
            {
                foreach (Transform child in other.gameObject.transform)
                {
                    if (child.name == "HPUI")
                    {
                        child.gameObject.SetActive(true);
                        child_obj = child.gameObject;
                    }
                }
                foreach (Transform child in child_obj.transform)
                {
                    if (child.name == "bluecycle")
                    {
                        UIobj = child.GetComponent<Image>();
                    }
                }
                UIobj.fillAmount = 1 - time;
            }
            if (time >= 1)
            {
                UIobj.fillAmount = 1f;
                child_obj.SetActive(false);
                once_flag = false;
                doubutsu_box_enable(false);
                other.gameObject.GetComponent<new_idou>().erabareteru_flag = true;
                /*//Debug.Log(obj_name);
                other.GetComponent<Moving_idou>().select_flag = true;
                if (old_object != other.gameObject && !null_kaihi_flag)
                {
                    Debug.Log("a");
                    old_object.GetComponent<Moving_idou>().select_flag = false;
                    old_object.GetComponent<Moving_idou>().comeback_flag = true;
                }
                old_object = other.gameObject;
                null_kaihi_flag = false;*/
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        time = 0;
        once_flag = true;
        child_obj.SetActive(false);
    }

    //動物たちのBoxColiderを管理
    public void doubutsu_box_enable(bool enabled)
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("doubutsu");
        foreach (GameObject doubutu in cubes)
        {
            if (enabled) doubutu.GetComponent<BoxCollider>().enabled = true;
            else doubutu.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
