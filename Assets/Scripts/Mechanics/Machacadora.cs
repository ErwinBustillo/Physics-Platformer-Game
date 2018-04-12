using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machacadora : MonoBehaviour {


	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Boli") {
			Destroy (other.gameObject);
			Score.score.substractScore (100);
			GameManager.gameManager.removeIntentos ();
			GameUI.gameUi.setTextValues ();
			FindObjectOfType<CannonController> ().enabled = true;
		}
	}

}
