using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Player:IComparable<Player> {

	public string nombre;
	public int score;

	public Player(string nombre, int score){
		this.nombre = nombre;
		this.score = score;
	}

	public int CompareTo(Player other){
		if (other == null) {
			return 1;
		}

		return score - other.score;
	}
}
