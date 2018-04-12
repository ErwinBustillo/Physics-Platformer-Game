using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	[SerializeField]
	private Transform target;
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public static CameraFollow camSingleton;

	private Vector3 originPos;
	// Use this for initialization
	void Start () {
		camSingleton = this;
		originPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		
		if (target == null)
		{
			transform.position = Vector3.Lerp (transform.position,originPos,dampTime);
			//transform.position = originPos;
			return;
		} else {
			Vector3 point = Camera.main.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); 
			Vector3 destination = transform.position + delta;
            //transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            transform.position = Vector3.Lerp(transform.position, destination, dampTime);

		}
	}

	public void setTarget(Transform t){
		target = t;
	}
}
