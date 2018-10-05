using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float moveSpeed = 5f;
    public float maxY = 10f; 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

        if (transform.position.y > maxY)
        {
            Destroy(gameObject);
        }
	}
}
