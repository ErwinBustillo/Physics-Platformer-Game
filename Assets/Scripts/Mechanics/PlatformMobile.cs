using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMobile : MonoBehaviour {

	public enum Direccion {
		Horizontal,Vertical
	};

	public Direccion direccion;

	public float timeSpeed = 2;
	public float targetXDistance=4f;
	public float targetYDistance=4f;

	private Vector3 startPos;

	private Vector3 targetPos;


	Vector3 pointB;

	IEnumerator Start () {
		Vector3 pointA = transform.position;

		// verificamos el target de la plataforma de acuerdo a la configuracion de la misma si se mueve horizontal o vertical 
		switch (direccion) {
		case Direccion.Horizontal:
			pointB = new Vector3 (pointA.x, pointA.y, targetXDistance);
			break;
		case Direccion.Vertical:
			pointB = new Vector3 (pointA.x,targetYDistance, pointA.z);
			break;
		}

		while (true) {
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 2));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 2));
		}
	}

	// Para oscilar entre el start point y el target point
	IEnumerator MoveObject (Transform t, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			t.position = Vector3.Lerp(startPos, endPos, i);//translacion
			yield return null;
		}
	}


	void OnCollisionEnter(Collision other){
		print ("CONTACTO CON PLATAFORMA");

	}



}
