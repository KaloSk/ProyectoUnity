using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

	public float bulletSpeed = 100;
	public float lifeSpawn = 3;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifeSpawn);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * bulletSpeed);
	}
}
