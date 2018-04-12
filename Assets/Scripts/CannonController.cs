using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {


	public Transform AngleRot;
	public Transform muzzle;
	public GameObject bulletPrefab;
	public float speedRot = 45f;
	public float speedForce = 5f;

	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");

		AngleRot.Rotate ( h * speedRot * Time.deltaTime, 0f,0f);
		if (Input.GetMouseButtonDown(0)) {
			Fire ();
		}
	}

	void Fire (){
		GameObject boli =Instantiate (bulletPrefab, muzzle.position, muzzle.rotation) as GameObject;
		CameraFollow.camSingleton.setTarget (boli.transform);
		Rigidbody rb = boli.GetComponent<Rigidbody> ();
		rb.AddForce (boli.transform.forward*speedForce,ForceMode.Impulse);
		this.enabled = false;
	}
}
