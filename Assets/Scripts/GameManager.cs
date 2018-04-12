using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[Header("Parametros del nivel")]
	public int numeroIntentos;
	public int puntosDelNivelPorCompletar;
	[HideInInspector]
	public int currentIntentos;
	public static GameManager gameManager;

	public CannonController cannonController;

	// Use this for initialization
	void Awake () {
		gameManager = this;
	}

	void Start(){
        currentIntentos = numeroIntentos;
		if (GameUI.gameUi.panelHelperHolder == null) {
			cannonController.enabled = true;
		} else {
			cannonController.enabled = false;
		}

		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentIntentos == 0) {
			print ("HAS PERDIDO");
			cannonController.enabled = false;
			GameUI.gameUi.setVisiblePanelGameOver (true);
		}
	}

	public void removeIntentos(){
		currentIntentos -= 1;
	}
}
