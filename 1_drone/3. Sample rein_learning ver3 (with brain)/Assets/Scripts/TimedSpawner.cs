using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedSpawner : MonoBehaviour {

    // public Text countText;
    // public Text finishText;

    public Transform spawnPos;
    public GameObject spawnee;

    public float randFloatX;
    public float randFloatZ;

    // public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    void Start() {
    	InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

	// Update is called once per frame
	public void SpawnObject() {
		randFloatX = Random.Range(-10f, 10f);
        randFloatZ = Random.Range(-2.5f, 2.5f);

        Instantiate(spawnee, new Vector3(spawnPos.position.x + randFloatX, spawnPos.position.y, spawnPos.position.z + randFloatZ) , spawnPos.rotation);
        // if(stopSpawning) {
        // 	CancelInvoke("SpawnObject");
        // }
        // SetCountText();
	} 
	// void SetCountText() {
	// 	countText.text = "Reward: " + count;
	// 	// if (stopSpawning) {
	// 	// 	finishText.text = "Episode Finished!";
	// 	// }
	// }     	

	// void OnTriggerEnter(Collider other) {
	// 	if(other.gameObject.CompareTag("Player")) {
	// 		stopSpawning = true;
	// 	}
	// }
}