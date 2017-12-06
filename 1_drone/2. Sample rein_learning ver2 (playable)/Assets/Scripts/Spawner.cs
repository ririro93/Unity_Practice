using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform spawnPos;
    public GameObject spawnee;

    public float randFloatX;
    public float randFloatZ;

    public float spawnTime;
    public float spawnDelay;

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Q)){

        	randFloatX = Random.Range(-10f, 10f);
        	randFloatZ = Random.Range(-2.5f, 2.5f);

        	Instantiate(spawnee, new Vector3(spawnPos.position.x + randFloatX, spawnPos.position.y, spawnPos.position.z + randFloatZ) , spawnPos.rotation);
        }
	}
}
