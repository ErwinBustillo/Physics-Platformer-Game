using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	private AudioSource audioSource;

	public AudioClip[] soundTracks;

	// Use this for initialization
	void Start () {

		audioSource = GetComponent<AudioSource> ();
		audioSource.loop = false;

	}

	AudioClip GetRandomClip(){
		return soundTracks [Random.Range (0, soundTracks.Length)];
	}

	void Update(){

		if (!audioSource.isPlaying) {
			print ("ENTRE");
			audioSource.clip = GetRandomClip ();
			audioSource.Play ();
		}
	}

}
