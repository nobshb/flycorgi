using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject bad_fire;

    public float minTimeTillNextThing = 0.5f;
    public float maxTimeTillNextThing = 1.5f;

    public float spawnY = 6f;
    public float minSpawnX = -9f;
    public float maxSpawnX = 9f;

    float _timeTillNextThing;

    // Use this for initialization
    void Start () {
        _timeTillNextThing = Random.Range(minTimeTillNextThing, maxTimeTillNextThing);
    }
	
	// Update is called once per frame
	void Update () {
        _timeTillNextThing -= Time.deltaTime;

        if (_timeTillNextThing <= 0)
        {
            // Create a thing!
            if (Random.value <= 0.5f)
            {
                GameObject newBadFire = Instantiate(bad_fire);
                newBadFire.transform.position = new Vector3(Random.Range(minSpawnX, maxSpawnX), spawnY, 0);
            }
            _timeTillNextThing = Random.Range(minTimeTillNextThing, maxTimeTillNextThing);
        }
    }
}
