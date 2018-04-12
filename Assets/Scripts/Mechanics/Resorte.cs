using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resorte : MonoBehaviour {

	public float springImpulseForce;

	[SerializeField]
	private Bullet boli;

	
	// Update is called once per frame
	void FixedUpdate () {
		if (boli != null) {
			boli.GetComponent<Rigidbody> ().AddForce (transform.up* springImpulseForce * Time.deltaTime, ForceMode.Impulse);
		}
	}

	void OnCollisionEnter(Collision other){
		print ("ENTRO BOLI EN RESORTE ");
		if (other.gameObject.tag == "Boli") {
			boli = other.gameObject.GetComponent<Bullet> ();
		}
	}

	void OnCollisionExit(Collision other){
		print ("SALIO BOLI DEL RESORTE ");
		boli = null;
	}
}
