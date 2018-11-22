using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_to_main : MonoBehaviour {

    [SerializeField]
    private CameraFader _cameraFader = null;
    [SerializeField]
    float time = 2f;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Load_main());
        }

    }
    IEnumerator Load_main()
    {
        _cameraFader.FadeOut(duration:time);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("main");
    }
}
