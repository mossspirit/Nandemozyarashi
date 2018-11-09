using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_controller : MonoBehaviour {

	AudioSource audioSource;
	AudioClip[] audioClips;

	void Start () 
	{
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Walk_SE(){
		audioSource.clip = audioClips[0];
		audioSource.Play; 
	}

	public void Wait_SE(){

	}
}
