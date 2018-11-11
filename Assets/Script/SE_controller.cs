using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_controller : MonoBehaviour {

    AudioSource audioSource;
    [System.NonSerialized]
	public AudioClip[] audioClips = new AudioClip[5];
    [System.NonSerialized]
    public bool SE_flag = false;

	void Start () 
	{
		audioSource = GetComponent<AudioSource>();
	}
	
	public void Walk_SE(){
		audioSource.clip = audioClips[0];
		audioSource.Play();
        SE_flag = false;
        Debug.Log("sa");
	}

	public void Wait_SE(){
        audioSource.clip = audioClips[1];
        audioSource.Play();
        SE_flag = false;
    }
    public void Zyare1_SE()
    {
        audioSource.clip = audioClips[2];
        audioSource.Play();
        SE_flag = false;
    }
    public void Zyare2_SE()
    {
        audioSource.clip = audioClips[3];
        audioSource.Play();
        SE_flag = false;
    }
    public void Zyare3_SE()
    {
        audioSource.clip = audioClips[4];
        audioSource.Play();
        SE_flag = false;
    }
    public void SE_flag_true()
    {
        SE_flag = true;
    }
}
