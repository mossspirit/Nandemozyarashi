using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_controller : MonoBehaviour {

    AudioSource audioSource;
    [System.NonSerialized]
	public AudioClip[] audioClips = new AudioClip[3];
    [System.NonSerialized]
    public bool SE_flag = false,oko_flag,bikkuri_flag,hatena_flag;

	void Start () 
	{
		audioSource = GetComponent<AudioSource>();
	}
    public void Zyare1_SE()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
        SE_flag = false;
        oko_flag = true;
        bikkuri_flag = false;
        hatena_flag = false;
    }
    public void Zyare2_SE()
    {
        audioSource.clip = audioClips[1];
        audioSource.Play();
        SE_flag = false;
        oko_flag = false;
        bikkuri_flag = true;
        hatena_flag = false;
    }
    public void Zyare3_SE()
    {
        audioSource.clip = audioClips[2];
        audioSource.Play();
        SE_flag = false;
        oko_flag = false;
        bikkuri_flag = false;
        hatena_flag = true;
    }
    public void SE_flag_true()
    {
        SE_flag = true;
    }
}
