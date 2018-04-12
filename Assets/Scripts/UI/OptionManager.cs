using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

	public GameObject BrandHolder;

	public void onClickResetScore(){
		if (PlayerPrefs.HasKey("puntaje")) {
			BrandHolder.SetActive (true);
			Score.score.clearScore ();
			StartCoroutine (showBrand ());
		} else {
			BrandHolder.SetActive (true);
			Text text = BrandHolder.transform.Find ("Text").GetComponent<Text>();
			text.text = "TU SCORE ES 0 NO PUEDES HACER ESTA OPERACION";
			StartCoroutine (showBrand ());
		}
	}


	IEnumerator showBrand(){
		yield return new WaitForSeconds (2f);
		BrandHolder.SetActive (false);
		yield return null;
	}
}
