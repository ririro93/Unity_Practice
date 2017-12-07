using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	public Transform droneTrs;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = gameObject.transform.position - droneTrs.position;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = droneTrs.position + offset;
	}
}
