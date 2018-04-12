using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour {
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Boli") {
			Destroy (other.gameObject);
			Score.score.substractScore (500);
			GameManager.gameManager.removeIntentos ();
			GameUI.gameUi.setTextValues ();
			FindObjectOfType<CannonController> ().enabled = true;
		}
	}
}
