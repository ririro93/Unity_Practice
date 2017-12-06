using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform spawnPos;
    public GameObject spawnee;

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Q))
        {
            Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
        }
	}
}
