using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

	[Header ("Panel Game Settings")]
	public GameObject panelGame;
	public Text textoIntentos;
	public Text textoTotalScore;

	public Text textoAngulo;
	public Text textoFuerza; 
	public Text textoDistancia;

	[Header ("Panel Helper Holder Settings")]
	public GameObject panelHelperHolder;
	public GameObject [] panelesHelpers;
	int indexHelperTeller = 0; 

	[Header ("Panel Game Over Settings")]
	public GameObject panelGameOver;
	public Text score;
	public Text pointsLevelText;
	[Header ("Panel Complete Level Settings")]
	public GameObject panelCompleteLevel;
	public Text textoNewTotalScore;
	public Text pointsWonLevelText;

	public static GameUI gameUi;
	public CannonController cannon;
	float angle;

	private Score ScoreManager;
	private AudioManager audioManager;

	void Awake(){
		if (cannon == null) {
			cannon = FindObjectOfType<CannonController> ();
		}

		if (Score.score == null) {
			print ("error missing scoremanager");
			return;
		}
		gameUi = this;
		ScoreManager = GameObject.FindObjectOfType<Score> () ;
		audioManager = GameObject.FindObjectOfType<AudioManager> ();
		

	}

	// Use this for initialization
	void Start () {

		if (panelesHelpers.Length == 0) {
			print ("HEY YOU FORGOT ADD PANELS INSIDE" + gameObject.name);
			GameUI.gameUi.setVisiblePanelGame(true);

		} else {
			panelesHelpers [indexHelperTeller].SetActive (true);
			cannon.enabled = false;
		}

		panelHelperHolder.SetActive (true);
     
        textoIntentos.text = "Intentos: " + GameManager.gameManager.numeroIntentos;
		textoTotalScore.text = "Total Score: " + Score.score.scoreRank;
		textoAngulo.text = "Angulo(grades) : " + cannon.AngleRot.transform.localRotation.x % 180;
		textoFuerza.text = "Fuerza(N) : " + cannon.speedForce;
		textoDistancia.text = "Distance(x,y) "+0 +"m";
	}

	//por bugasos
	void Update(){
		angle = cannon.AngleRot.transform.localRotation.x;

		if (angle > 0) {
			angle = angle*-1;
		} else{
			if (angle < 0) {
				angle = angle*-1;
			} else {
				angle = 0;
			}
		} 
		//ang = ang % 180;
		angle = angle % 360;
		textoAngulo.text = "Angulo(grades) : "+angle.ToString("F2");
		//textoDistancia.text = "Distance(x,y) "+0 +"m";
		if (Input.GetKeyDown(KeyCode.Escape)) {
			
			if (FindObjectOfType<Bullet> () != null){
				Destroy (FindObjectOfType<Bullet> ().gameObject);
			}
			CannonController cc = FindObjectOfType<CannonController> ();
			cc.enabled = false;
			setVisiblePanelGameOver (true);
		}
	}

	//METODOS GAME UI
	#region
	public void onClickContinue(){
		Score.score.saveScore ();
		DontDestroyOnLoad (ScoreManager.gameObject);
		DontDestroyOnLoad (audioManager.gameObject);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void onClickGoToMenu(){
		Score.score.saveScore ();
		Destroy (ScoreManager.gameObject);
		Destroy (audioManager.gameObject);
		SceneManager.LoadScene (0);
	}

	public void onClickRetryLevel(){
		Score.score.saveScore ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void setVisiblePanelGameOver(bool active){
		panelGame.SetActive (!active);
		panelGameOver.SetActive (active);
		score.text = "Total Score: " + Score.score.scoreRank;
		pointsLevelText.text = "Points Level: " + GameManager.gameManager.puntosDelNivelPorCompletar;
	}

	public void setVisiblePanelCompleteLevel(bool active){
		panelGame.SetActive (!active);
		panelCompleteLevel.SetActive (active);
		textoNewTotalScore.text = "Total Score: " + Score.score.scoreRank;
		pointsWonLevelText.text = "Points Won Level: " + GameManager.gameManager.puntosDelNivelPorCompletar;
	}

	public void setVisiblePanelGame(bool active){
		panelCompleteLevel.SetActive (!active);
		panelGameOver.SetActive (!active);
		panelGame.SetActive (active);

		GameObject winzone = GameObject.FindGameObjectWithTag("Finish");

		Debug.Log (winzone.gameObject.name + "");

		Vector3 distancia = cannon.gameObject.transform.position - winzone.gameObject.transform.position;

		print (distancia);
		if (distancia.z < 0f) {
			distancia.z *= -1f;
		}
		textoDistancia.text = "Distance :(m)" +distancia.z.ToString("F2") ;
		textoTotalScore.text = "Total Score: " + Score.score.scoreRank;
	}

	public void setTextValues(){
		textoIntentos.text = "Intentos: " + GameManager.gameManager.currentIntentos;
		textoTotalScore.text = "Total Score: " + Score.score.scoreRank;
	}
	#endregion

	///METODOS PARA EL HELPER TELLER
	#region
	public void OnClickNext(){
		panelesHelpers [indexHelperTeller].SetActive (false);
		indexHelperTeller += 1;
		if (panelesHelpers.Length == indexHelperTeller) {
			GameManager.gameManager.cannonController.enabled = true;
			cannon.enabled = true;
			setVisiblePanelGame (true);
			Destroy (panelHelperHolder);
		} else {
			panelesHelpers [indexHelperTeller].SetActive (true);
		}
	}
	#endregion
}
