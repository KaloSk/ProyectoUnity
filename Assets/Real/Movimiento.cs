using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {

	public int x=0,y=0,z=0;

	public Transform cam;
	public float camX, camY, camZ;
	float closeCamY = 0, closeCamZ = 0;

	// Use this for initialization
	void Start () {		
		//transform.position = new Vector3(1,0,0);
		camX = cam.transform.position.x;
		camY = cam.transform.position.y;
		camZ = cam.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			if (Input.GetKeyDown (KeyCode.W)) {
				z++;
				transform.position = new Vector3 (x, y, z);
			} else if (Input.GetKeyDown (KeyCode.S)) {
				z--;
				transform.position = new Vector3 (x, y, z);
			} else if (Input.GetKeyDown (KeyCode.A)) {
				x--;
				transform.position = new Vector3 (x, y, z);
			} else if (Input.GetKeyDown (KeyCode.D)) {
				x++;
				transform.position = new Vector3 (x, y, z);
			} else if (Input.GetAxis ("Mouse ScrollWheel") > 0f) {
				closeCamY--;
				closeCamZ--;
			} else if (Input.GetAxis ("Mouse ScrollWheel") < 0f) {
				closeCamY++;
				closeCamZ++;
			}
			cam.position = new Vector3(x+camX,y+camY+closeCamY,z+camZ+closeCamZ);
		}



	}
}
