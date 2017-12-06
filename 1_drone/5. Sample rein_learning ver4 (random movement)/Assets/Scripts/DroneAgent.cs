using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneAgent : Agent {

	//to visualize in the editor
	[SerializeField]
	private Text text;
	[SerializeField]
	private float moveHorizontal;


	int solved;
	public Transform playerPos;
	public int reward1;
	public int reward2;
	public int totalReward;
	public float speed;
	public bool stopSpawning = false;
	public Text finishText;
	public Text stepCount;
	public Text lifeCount;
	private int steps = 0;
	private Vector3 vec;
	public int life;
	public int act;
	public int actCount;
	public int episodes = 1;

	private Rigidbody rb;
	// private int count;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		life = 3;
		finishText.text = "";
		vec = new Vector3(0, 0, -8);
		// stepCount.text = "";
	}
	
	void Update() {
		//referencing droneagent to get variable life
		GameObject theDestroyer = GameObject.Find("Destroyer Back");
		CountReward destroyerBack = theDestroyer.GetComponent<CountReward>();
		reward2 = destroyerBack.count;
		if (actCount == 0) {
			act = Random.Range(0, 3);
		}

	}

	// void FixedUpdate() {
	// 	float moveHorizontal = Input.GetAxis("Horizontal");
	// 	float moveVertical = Input.GetAxis("Vertical");

	// 	Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
	// 	rb.AddForce(movement * speed);
	// }
	
	void OnTriggerEnter(Collider coll) {
		if(coll.gameObject.tag == "Sphere") {
			reward1 -= 20;
			life -= 1;
			coll.gameObject.SetActive(false);
			gameObject.transform.position = vec; 
			gameObject.transform.rotation = Quaternion.identity; 
			moveHorizontal = 0;
			if (life == 0) {
				done = true;
				SetFinishText();
			}
			// Instantiate(playa, vec, Quaternion.identity);
		}
		if(coll.gameObject.tag == "Destroyer") {
			reward1 -= 5;
			life -= 1;
			gameObject.transform.position = vec; 
			gameObject.transform.rotation = Quaternion.identity; 
			moveHorizontal = 0;
			if (life == 0) {
				done = true;
				SetFinishText();
			}
			// Instantiate(playa, vec, Quaternion.identity);

		}
	}

	// void FallOff() {
	// 	if(playerPos.position.y < -5 ) {
	// 		reward1 -= 5;
	// 	}		
	// }

	void SetFinishText() {
		finishText.text = "Episode Finished!";
		totalReward = reward1 + reward2;
		text.text = "Final reward: " + (reward1 + reward2);
		stepCount.text = "Final step: " + steps;
		episodes += 1;
	}

	public override List<float> CollectState() {
		List<float> state = new List<float>();
		return state;
	}

	public override void AgentStep(float[] action) {


		if(text != null)
			text.text = "Reward1: " + reward1 + "  Reward2: " + reward2;
			// Debug.Log(reward2);
			lifeCount.text = "Episodes: " + episodes + "\nLives: " + life;
			
		switch(act) {
			case 0:
				break;
			case 1:
				moveHorizontal -= 0.1f;
				break;
			case 2:
				moveHorizontal += 0.1f;
				break;
			default:
				return;
		}

		// Vector3 movement = new Vector3(moveHorizontal * speed, rb.velocity.y, rb.velocity.z);
		// rb.velocity = movement;
		rb.transform.position = new Vector3(moveHorizontal * speed, rb.transform.position.y, rb.transform.position.z);
		
		steps += 1;
		if(stepCount != null)
			stepCount.text = "steps: " + steps;
		actCount = steps % 4;
	}


	public override void AgentReset() {
		reward1 = 0;
		reward2 = 0;
		life = 15;
		finishText.text = "";
	}
}