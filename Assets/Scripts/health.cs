using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public float health;

public class health : MonoBehaviour {

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health == 0){
			Destroy(gameObject);
		}
	}
}
