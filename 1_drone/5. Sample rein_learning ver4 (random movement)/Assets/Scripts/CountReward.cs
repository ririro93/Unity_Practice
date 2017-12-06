using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountReward : MonoBehaviour {

	public int life;
	public int count = 0;
	public Text reward2;
	
	// Update is called once per frame
	void Update () {
		//referencing droneagent to get variable life
		GameObject thePlayer = GameObject.Find("Player");
		DroneAgent droneAgent = thePlayer.GetComponent<DroneAgent>();
		life = droneAgent.life;
		if (life == 15) {
			count = 0;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Sphere"){
			count += 1;
		}
	}
}
