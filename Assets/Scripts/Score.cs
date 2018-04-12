using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public static Score score;

	public int scoreRank;

	void Awake(){
		score = this;

	}
	// Use this for initialization
	void Start () {
		///aqui llamar a playerpref para cargar los puntos guardados
		if (PlayerPrefs.HasKey("puntaje")) {
			getScore();

		} else {
			scoreRank = 0;
		}

	}



	public void getScore(){
		scoreRank = PlayerPrefs.GetInt ("puntaje", 0);
	}

	public void setScore(int amount){
		scoreRank += amount;
	}

	public void substractScore(int amount){
		scoreRank -= amount;
	}


	public void saveScore(){
		PlayerPrefs.SetInt ("puntaje",scoreRank);
		PlayerPrefs.Save ();
	}

	public void clearScore(){
		PlayerPrefs.DeleteKey ("puntaje");
		scoreRank = 0;
	}

}
