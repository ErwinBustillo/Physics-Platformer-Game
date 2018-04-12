using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour  {

	public List<Player> jugadores = new List<Player>();
	public GameObject ContentHolder;
	public GameObject prefabPlayerField;

	void Awake(){
		if (PlayerPrefs.HasKey("puntaje")) {
			print ("VERDADERO");
			jugadores.Add (new Player ("Boli",PlayerPrefs.GetInt("puntaje")));
		}
	}
	void Start(){

		jugadores.Sort ();
		jugadores.Reverse ();

		foreach (var item in jugadores) {
			GameObject go = Instantiate (prefabPlayerField);
			go.transform.SetParent (ContentHolder.transform, false);
			go.transform.Find ("TextName").GetComponent<Text>().text = item.nombre;
			go.transform.Find ("TextScore").GetComponent<Text>().text = item.score+"";
			print (item.nombre + " " + item.score);
		}
	}



}

