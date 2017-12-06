using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereMovement : MonoBehaviour {

	public Text finishText;

    public bool stopSpawning = false;

	public Transform spherePos;
	public Vector3 dronePos;
	public Vector3 sphereDest;
	public Vector3 sphereDir;
	public Vector3 randPos;
	public float speed;

	private Rigidbody rb;



	// Use this for initialization
	void Start () {
		GameObject playerPos = GameObject.FindWithTag("Player");
		if ( playerPos != null) {
			dronePos = playerPos.transform.position;
		}
		rb = GetComponent<Rigidbody>();
		randPos = new Vector3(dronePos.x + Random.Range(-5.0f, 5.0f), 0, Random.Range(-8.0f, -6.0f));
		sphereDir = randPos - spherePos.transform.position;
		// if(stopSpawning){
		// 	SetFinishText();
		// }
		// else {
		// 	finishText.text = "";
		// }
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3(sphereDir.x, sphereDir.y, sphereDir.z);
		rb.velocity = (movement * speed);
	}

	// void OnCollisionEnter(Collision coll) {
	// 	if(coll.gameObject.name == "Player") {
	// 		gameObject.SetActive(false);
	// 		Debug.Log("asdfasdfa");
	// 		stopSpawning = true;
	// 	}
	// }

	// void SetFinishText() {
	// 	finishText.text = "Episode Finished!";
	// }

	// void Deactivation() {
	// 	Deactivate(gameObject);
	// }

// 	void OnCollisionEnter(Collision collision) {
// 		stopSpawning = true;
// 	}
}
