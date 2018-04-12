using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

	public Text textoScoreShop;

	public GameObject BrandShop;

	// Use this for initialization
	void Start () {
		textoScoreShop.text = "SCORE :" + Score.score.scoreRank; 
	}

	public void OnClickBuy(){
		/*if (Score.score.scoreRank < objeto.valor) {
			BrandShop.SetActive (true);
			Text text = BrandShop.transform.Find ("Text");
			text.text = "NO TIENES PUNTOS SUFICIENTES PARA COMPRAR ESTO";
			StartCourutine(setVisibleBrand);
		}
		else{
			BrandShop.SetActive (true);
			StartCourutine(setVisibleBrand);
		}*/
	}

	IEnumerator setVisibleBrand(){
		yield return new WaitForSeconds (1f);
		BrandShop.SetActive (false);
		yield return null;
	}

}
