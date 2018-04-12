using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iman : MonoBehaviour {

	[Range(0,3)]
	public float gravityRadiusAttraction;
	public float forceValue = 20f;
	public SphereCollider esferaGravitatoria;
	public GameObject particulas;

	private List<Rigidbody> cuerpos = new List<Rigidbody> ();


	// Use this for initialization
	void Start () {
		esferaGravitatoria.radius = gravityRadiusAttraction;
	}
	
	private void FixedUpdate()
	{
		if(cuerpos.Count > 0)
		{
			for (int index = 0; index < cuerpos.Count; index++)
			{
				Rigidbody asteroid = cuerpos[index];
				Vector3 forceDirection = (asteroid.transform.position - transform.position).normalized * -1;
				asteroid.AddForce(forceDirection * forceValue);
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Boli") {
			cuerpos.Add (other.GetComponent<Rigidbody> ());
			StartCoroutine (decreaseRadius ());
		}
		
	}


	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Boli") {
			cuerpos.Remove (other.GetComponent<Rigidbody> ());
			StartCoroutine (restablishGravityForce ());
		}
	}

	IEnumerator decreaseRadius(){
		yield return  new WaitForSeconds (5f);
		print ("Descrementar radio");
		esferaGravitatoria.radius = 0f;
		particulas.SetActive (false);
		yield return null;
	}

	IEnumerator restablishGravityForce(){
		yield return  new WaitForSeconds (3f);
		print ("RESTABLECIDO RADIO DE LA ESFERA");
		esferaGravitatoria.radius = gravityRadiusAttraction;
		particulas.SetActive (true);
		yield return null;
	}
}
