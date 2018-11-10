using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_controller : MonoBehaviour {

    AudioSource audioSource;
    [System.NonSerialized]
	public AudioClip[] audioClips = new AudioClip[5];

	void Start () 
	{
		audioSource = GetComponent<AudioSource>();
	}
	
	public void Walk_SE(){
		audioSource.clip = audioClips[0];
		audioSource.Play();
        Debug.Log("sa");
	}

	public void Wait_SE(){
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }
    public void Zyare1_SE()
    {
        audioSource.clip = audioClips[2];
        audioSource.Play();
    }
    public void Zyare2_SE()
    {
        audioSource.clip = audioClips[3];
        audioSource.Play();
    }
    public void Zyare3_SE()
    {
        audioSource.clip = audioClips[4];
        audioSource.Play();
    }
}
