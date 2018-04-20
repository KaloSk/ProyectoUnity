using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour {
	
	public float speed = 1;
	public float angularVelocity = 100;

    public GameObject bullet;

    public List<Color> colors = new List<Color>();

    int colorIndex = 0;

    public SpriteRenderer spriteRenderer;

	class Axis{
		string name;
		KeyCode negative;
		KeyCode positive;

		public Axis(string s, KeyCode n, KeyCode p){
			name = s;
			negative = n;
			positive = p;
		}

		public string getName(){return name;}
		public KeyCode getNegative(){return negative;}
		public KeyCode getPositive(){return positive;}

	}

	List<Axis> axisList = new List<Axis>();

	// Use this for initialization
	void Start () {
        spriteRenderer.color = colors[colorIndex];
		axisList.Add (new Axis ("Horizontal", KeyCode.A, KeyCode.D));
		axisList.Add (new Axis ("Vertical", KeyCode.S, KeyCode.W));
		axisList.Add (new Axis ("Arrow_H", KeyCode.D, KeyCode.A));
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * GetAxis ("Horizontal") * speed * Time.deltaTime, Space.World);
		transform.Translate (Vector3.up * GetAxis ("Vertical") * speed * Time.deltaTime, Space.World);

        //transform.Rotate (Vector3.forward * GetAxis ("Arrow_H") * angularVelocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E)) {
            MoveColor();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
	}

    void MoveColor() {
        colorIndex = (colorIndex >= colors.Count -1 ? 0 : colorIndex+1);
        spriteRenderer.color = colors[colorIndex];
    }

	int GetAxis(string axisName){
		Axis axis = axisList.Find(target => target.getName() == axisName);
		int axisValue = 0;
		if (axis != null) {
			if(Input.GetKey(axis.getNegative())) {
				axisValue-=1;
			}
			else if(Input.GetKey(axis.getPositive())){
				axisValue+=1;
			}
		}

		return axisValue;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Block")) {
			Debug.Log ("xxx");
		}
	}

    void Shoot()
    {
        SpriteRenderer temp = Instantiate(bullet, transform.Find("Cannon").position, transform.rotation).GetComponent<SpriteRenderer>();
        temp.color = spriteRenderer.color;
        Destroy(temp.gameObject, 2);
    }

    /*void OnCollisionEnter2D(Collision2D other){
		if (other.collider.CompareTag ("Block")) {
			Debug.Log ("xxx");
		}
	}*/

}
