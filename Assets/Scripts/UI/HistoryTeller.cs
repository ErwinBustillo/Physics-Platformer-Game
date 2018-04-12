using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HistoryTeller : MonoBehaviour {

	public GameObject [] panelesDeHistoria;

	int index = 0; 

	private Score ScoreManager;
	private AudioManager audioManager;

	void Awake(){
		ScoreManager = GameObject.FindObjectOfType<Score> () ;
		audioManager = GameObject.FindObjectOfType<AudioManager> ();
	}

	// Use this for initialization
	void Start () {		
		panelesDeHistoria [index].SetActive (true);
	}

	public void OnClickNext(){
		panelesDeHistoria [index].SetActive (false);
		index += 1;
		panelesDeHistoria [index].SetActive (true);
	}

	public void OnClickGoBackToMainMenu(){
		Destroy (ScoreManager.gameObject);
		Destroy (audioManager.gameObject);
		SceneManager.LoadScene (0);
	}
	public void OnClickStartTest(){
		DontDestroyOnLoad (ScoreManager.gameObject);
		DontDestroyOnLoad (audioManager.gameObject);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex +1);
	}

	public void OnClickContinueNextTest(){
		DontDestroyOnLoad (ScoreManager.gameObject);
		DontDestroyOnLoad (audioManager.gameObject);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void onClickFinishedHistory(){
		Destroy (ScoreManager.gameObject);
		Destroy (audioManager.gameObject);
		SceneManager.LoadScene (0);
	}
}
