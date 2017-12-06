using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardFromObstacle : MonoBehaviour {

	public int count;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Player") {
			gameObject.SetActive(false);
		}
		if(other.gameObject.tag == "Ground") {
			count += 1;
			gameObject.SetActive(false);
		}
	}
}
