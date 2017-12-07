using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAgent : Agent {

	public GameObject obstacle;

	public int movement;
	public float speed;
	public int count;

	private Rigidbody rb;
	public float coordsObsX;
	

	public override void InitializeAgent() {
		rb = GetComponent<Rigidbody>();
	}



	public override List<float> CollectState()	{
		List<float> state = new List<float>();
		state.Add(transform.position.x);
		state.Add(coordsObsX);

		return state;
	}

	public override void AgentStep(float[] act)	{

		// what the actions do
		switch((int)act[0]) {
			case 0:
				if(movement * speed < -8.5) {
					return;
				}
				else {
				movement -= 1;
				}
				break;
			case 1:
				if(movement * speed > 8.5) {
					return;
				} 
				else {movement += 1;
				}
				break;
			default:
				break;
		}
		rb.transform.position = new Vector3
		(
			Mathf.Clamp(movement * speed, -8.5f, 8.5f),
			rb.transform.position.y,
			rb.transform.position.z
		);

		if(count == 0) {
			done = true;
			reward = 1f;
		} else {
			done = false;
			reward = -0.001f;
		}
	}

	public override void AgentReset()	{
		gameObject.transform.position = new Vector3(0, 0, 0);
		gameObject.transform.rotation = Quaternion.identity;
		movement = 0;
		count = 2;
	}

	public override void AgentOnDone()	{

	}



	public void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Obstacle") {
			count -= 1;
			Destroy(other.gameObject);
		}
	}

	void Update() {
			// get coordsX value from TestAcademy
		GameObject theAcademy = GameObject.Find("TestAcademy");
		TestAcademy testAcademy = theAcademy.GetComponent<TestAcademy>();
		coordsObsX = testAcademy.coordsX;
		// Debug.Log(coordsObsX);
	}
}
