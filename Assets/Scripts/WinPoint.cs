using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPoint : MonoBehaviour {




	void OnCollisionEnter(Collision other){
		print ("GANE");
		if (other.gameObject.tag == "Boli") {
			Destroy (other.gameObject);

			if (GameManager.gameManager.currentIntentos == GameManager.gameManager.numeroIntentos) { // si paso el nivel sin fallos
				Score.score.setScore(100*GameManager.gameManager.currentIntentos+GameManager.gameManager.puntosDelNivelPorCompletar);
			} else {
				Score.score.setScore(GameManager.gameManager.currentIntentos+GameManager.gameManager.puntosDelNivelPorCompletar);
			}
			GameManager.gameManager.cannonController.enabled = false;
			GameUI.gameUi.setVisiblePanelCompleteLevel (true);
		}
	}
}
