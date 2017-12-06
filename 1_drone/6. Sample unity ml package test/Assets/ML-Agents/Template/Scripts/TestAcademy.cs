using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAcademy : Academy {

	public Transform spawnerPos;
	public GameObject spawnee;
	
	public float spawnTime;
	public float spawnDelay;
	public float  coordsX;

	private Rigidbody spawneeRB;
	private float randX;

	public override void InitializeAcademy() {
		spawneeRB = spawnee.GetComponent<Rigidbody>();
		InvokeRepeating("SpawnBall", spawnTime, spawnDelay);		
	}

	public override void AcademyReset()	{


	}

	public override void AcademyStep()	{

	}

	void SpawnBall() {
		Rigidbody clone;
		randX = Random.Range(-10f, 10f);
		coordsX = spawnerPos.position.x + randX;
		clone = Instantiate(
			spawneeRB, 
			new Vector3(coordsX, spawnerPos.position.y, spawnerPos.position.z), 
			Quaternion.identity) as Rigidbody;
		// clone.velocity = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);
	}

}
