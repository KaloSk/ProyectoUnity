using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {

	public float speed;
	public Vector3 direction;

	public Vector3 limit;

	public Transform cam;
	float camX, camY, camZ;

	float timer = 1;

    //10/04/18//
    Rigidbody playerRB;
    int mode = 0;
    Vector3 firstPosition;

    public AudioClip backgroundMusic;
    public AudioSource camSource;

    // Use this for initialization
    void Start () {		
		//transform.position = new Vector3(1,0,0);
		if(cam!=null){
			camX = cam.transform.position.x;
			camY = cam.transform.position.y;
			camZ = cam.transform.position.z;
		}

        playerRB = GetComponent<Rigidbody>();
        firstPosition = transform.position;
        camSource.PlayOneShot(backgroundMusic);
    }
	
	// Update is called once per frame
	void Update () {

		/*if (transform.position.x >= limit) {
			speed = 0;
			transform.position = new Vector3 (limit, transform.position.y, transform.position.z);
		}

		transform.Translate (direction * speed * Time.deltaTime);
		cam.position = new Vector3(transform.position.x+camX,transform.position.y+camY+closeCamY,transform.position.z+camZ+closeCamZ);*/

		/*Vector3 currentMovement = Vector3.zero;

		if (transform.position.x < limit.x) {
			currentMovement.x = direction.x * speed; 
		} 

		if (transform.position.y < limit.y) {
			currentMovement.y = direction.y * speed;
		}

		if (transform.position.z < limit.z) {
			currentMovement.z = direction.z * speed;
		}

		transform.Translate (currentMovement * Time.deltaTime);
		cam.position = new Vector3(transform.position.x+camX,transform.position.y+camY+closeCamY,transform.position.z+camZ+closeCamZ);
		*/



		if (Input.anyKey) {
			if (Input.GetKey (KeyCode.W) && transform.position.z < limit.x) {
                if (mode == 1)
                    transform.position += new Vector3 (0, 0, speed * Time.deltaTime);
                else
                    GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(0, 0, speed * Time.deltaTime));
				//transform.Rotate (new Vector3 (speed*15, 0, 0) * Time.deltaTime);
               
            } else if (Input.GetKey (KeyCode.S) && transform.position.z > -limit.z) {
                if (mode == 1)
                    transform.position += new Vector3 (0, 0, -speed * Time.deltaTime);
                else
                    GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(0, 0, -speed * Time.deltaTime));
                //transform.Rotate (new Vector3 (-speed*15, 0, 0) * Time.deltaTime);
            } 
			if (Input.GetKey (KeyCode.A) && transform.position.x > -limit.x) {
                if (mode == 1)
                    transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);
                else
                    GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(-speed * Time.deltaTime, 0, 0));
                //transform.Rotate (new Vector3 (0, 0, speed*15) * Time.deltaTime);
                //cam.Rotate(new Vector3(0, -speed * 15, 0) * Time.deltaTime);
            } 
			if (Input.GetKey (KeyCode.D) && transform.position.x < limit.x) {
                if(mode == 1)
                    transform.position += new Vector3 (speed * Time.deltaTime,0 ,0);
                else 
                    GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(speed * Time.deltaTime, 0, 0));
                //transform.Rotate (new Vector3 (0, 0, -speed*15) * Time.deltaTime);
                //cam.Rotate(new Vector3(0, speed * 15, 0) * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.M)) {
                mode = 1;
                Debug.Log("Modo Random");
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                mode = 0;
                Debug.Log("Modo Rigid");
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
            //cam.position = new Vector3(x+camX,y+camY+closeCamY,z+camZ+closeCamZ);
        }

        /*Timer delta*/
        /*timer -= Time.deltaTime;
		if (timer <= 0) {
			//action
		}*/

        //transform.position = Vector3.MoveTowards (transform.position, limit, speed * Time.deltaTime);
        /*if (transform.position.x == limit.x) {
			limit.x *= -1;
		}

		if (transform.position.y == limit.y) {
			limit.y *= -1;
		}

		if (transform.position.z == limit.z) {
			limit.z *= -1;
		}*/

        if (cam != null)
        {
            cam.position = new Vector3(transform.position.x + camX, transform.position.y + camY, transform.position.z + camZ);
        }
        //cam.position = transform.position;
    }

    public void RestartGame() {
        transform.position = firstPosition;
        Debug.Log("Reset Game");
    }
}
