using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour {

	public float angleVelocity = 1;
	public float speed = 1;

	public AudioClip bang;

	public Transform gun;

	public GameObject playerBullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Input.GetAxis ("Mouse X") * Vector3.up * Time.deltaTime * angleVelocity);
		transform.Translate (Input.GetAxis("Horizontal") * Vector3.right * Time.deltaTime * speed);
		transform.Translate (Input.GetAxis("Vertical") * Vector3.left * Time.deltaTime * speed);



		if (Input.GetMouseButtonDown (0)) {
			gun.GetComponent<AudioSource> ().PlayOneShot (bang);
			playerBullet.transform.Rotate (new Vector3 (-90, 0));
			Instantiate(playerBullet, gun.Find ("Cannon").position, transform.rotation);
		}
	}
}
