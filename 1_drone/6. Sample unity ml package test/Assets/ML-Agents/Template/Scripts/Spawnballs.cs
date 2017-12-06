using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnballs : MonoBehaviour {

	public Transform spawnPos;
	public GameObject spawnee;
	public float spawnTime;
	public float spawnDelay;

	private float randX;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnBall", spawnTime, spawnDelay);		
	}
	
	void SpawnBall() {
		randX = Random.Range(-10f, 10f);
		Instantiate(spawnee, new Vector3(spawnPos.position.x + randX, spawnPos.position.y, spawnPos.position.z), Quaternion.identity);
	}
}
