using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {


	public float speed;
	// public Text countText;
	public bool stopSpawning = false;
	public Text finishText;

	private Rigidbody rb;
	// private int count;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		// count = 0;
		// SetCountText();
		finishText.text = "";
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
		rb.AddForce(movement * speed);
	}
	
	void OnCollisionEnter(Collision coll) {
		if(coll.gameObject.tag == "Sphere") {
			Debug.Log("asdfasdfa");
			stopSpawning = true;
			SetFinishText();
		}
	}

	void SetFinishText() {
		finishText.text = "Episode Finished!";
	}


	// void SetCountText() {
	// 	countText.text = "Number of Collisions: " + count.ToString();
	// 	if (count >= 10) {
	// 		finishText.text = "Episode Finished";
	// 	}
	// }
}