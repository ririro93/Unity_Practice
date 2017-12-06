using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneAgent : Agent {

	[SerializeField] //to visualize in the editor
	private float currentNumber;
	[SerializeField]
	private float targetNumber;
	[SerializeField]
	private Text text;
	[SerializeField]
	private float moveHorizontal;


	int solved;
	public Transform playerPos;
	public int reward1;
	public int reward2;
	public float speed;
	public bool stopSpawning = false;
	public Text finishText;
	public Text stepCount;
	public Text lifeCount;
	private int steps = 0;
	private Vector3 vec;
	public int life;

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
		text.text = "Final reward: " + (reward1 + reward2);
		stepCount.text = "Final step: " + steps;
	}

	public override List<float> CollectState() {
		List<float> state = new List<float>();
		return state;
	}

	public override void AgentStep(float[] action) {
		if(text != null)
			text.text = "Reward1: " + reward1 + "  Reward2: " + reward2;
			// Debug.Log(reward2);
			lifeCount.text = "Lives: " + life;
			
		switch((int)action[0]) {
			case 0:
				break;
			case 1:
				currentNumber -= 0.001f;
				moveHorizontal -= 0.1f;
				break;
			case 2:
				currentNumber += 0.001f;
				moveHorizontal += 0.1f;
				break;
			default:
				return;
		}

		Vector3 movement = new Vector3(moveHorizontal * speed, rb.velocity.y, rb.velocity.z);
		rb.velocity = movement;
		steps += 1;
		if(stepCount != null)
			stepCount.text = "steps: " + steps;

		// if(currentNumber < -1.2f || currentNumber > 1.2f) {
		// 	reward = -1f;
		// 	done = true;
		// 	return;
		// }

		// float difference = Mathf.Abs(targetNumber - currentNumber);
		// if (difference <= 0.01f) {
		// 	solved++;
		// 	reward = 1;
		// 	done = true;
		// 	return;
		// }
	}


	public override void AgentReset() {
		reward1 = 0;
		reward2 = 0;
		life = 15;
		finishText.text = "";
	}
}