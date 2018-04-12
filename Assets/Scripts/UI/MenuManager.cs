using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public GameObject panelMainMenu; 
	public GameObject panelShop;
	public GameObject panelRank;
	public GameObject panelOptions;


	private Score ScoreManager;
	private AudioManager audioManager;


	void Start(){
		ScoreManager = GameObject.FindObjectOfType<Score> () ;
		audioManager = GameObject.FindObjectOfType<AudioManager> ();

		panelMainMenu.SetActive (true);
	}
	public void onClickPlay(){
		ScoreManager.saveScore ();
		DontDestroyOnLoad (ScoreManager.gameObject);
		DontDestroyOnLoad (audioManager.gameObject);
		SceneManager.LoadScene (1);
	}

	public void onClickShop(){
		panelMainMenu.SetActive (false);
		panelShop.SetActive (true);
	}

	public void onClickRank(){
		panelMainMenu.SetActive (false);
		panelRank.SetActive (true);

	}

	public void onClickOptions(){
		panelMainMenu.SetActive (false);
		panelOptions.SetActive (true);
	}

	public void onClickCancelPanelShop(){
		panelShop.SetActive (false);
		panelMainMenu.SetActive (true);

	}
	public void onClickCancelPanelRank(){
		
		panelRank.SetActive (false);
		panelMainMenu.SetActive (true);
	}

	public void onClickCancelPanelOptions(){
		panelOptions.SetActive (false);
		panelMainMenu.SetActive (true);
	}

	public void onClickExit(){
		Application.Quit ();
	}
}
