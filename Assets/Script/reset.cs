using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private CameraFader _cameraFader = null;

    void Start ()
    {
        _cameraFader.FadeOut(duration: 0.5f);
        _cameraFader.FadeIn(duration: 5f);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("start");
        }
    }
}
