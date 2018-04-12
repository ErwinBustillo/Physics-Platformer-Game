using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veladora : MonoBehaviour {

	public float impulseForce = 15f;

	[SerializeField]
	private Bullet boli;

	// Update is called once per frame
	void FixedUpdate () {
		if (boli != null) {
			boli.GetComponent<Rigidbody> ().AddForce (Vector3.up * impulseForce * Time.deltaTime, ForceMode.VelocityChange);

		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag =="Boli") {
			print ("ENtro boli");
			boli = other.gameObject.GetComponent<Bullet> ();
		}
	}
	void OnTriggerExit(Collider other){
		boli = null;

	}
}
