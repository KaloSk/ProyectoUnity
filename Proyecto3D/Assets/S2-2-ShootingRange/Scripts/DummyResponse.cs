using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyResponse : MonoBehaviour {



	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("PlayerBullet")) {
			Destroy (other.gameObject, 0);
			Destroy (gameObject, 0);

			ShootingRangeControl.score++;
		}
	}
}
