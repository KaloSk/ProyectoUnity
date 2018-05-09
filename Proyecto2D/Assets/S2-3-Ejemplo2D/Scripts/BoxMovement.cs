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
    public Transform sightDirection;
    public Transform sightCursor;


    public Vector3 mousePosition;
    //26-04-18

    public LineRenderer visorLine;

    //08-05-18//
    public Rigidbody2D rigidBody2D;
    Vector3 velocity;

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
		//axisList.Add (new Axis ("Arrow_H", KeyCode.LeftArrow, KeyCode.RightArrow));
	}

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        velocity = Vector3.zero;
        velocity.x = GetAxis("Horizontal") * speed;
        velocity.y = GetAxis("Vertical") * speed;
        
        //transform.Translate(Vector3.right * GetAxis("Horizontal") * speed * Time.deltaTime, Space.World);
        //transform.Translate(Vector3.up * GetAxis("Vertical") * speed * Time.deltaTime, Space.World);
        //transform.Rotate(Vector3.forward * GetAxis("Arrow_H") * angularVelocity * Time.deltaTime);

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        transform.up = (mousePosition - transform.position).normalized;
        
        if (Vector3.Distance(mousePosition, transform.position) >= 1)
        {
            sightCursor.position = mousePosition;
        }
        else {
            sightCursor.position = transform.position + sightDirection.up;
        }

        visorLine.SetPositions(new Vector3[] { transform.position, transform.position  + sightDirection.up * 3});

        //Debug.DrawLine(transform.position, mousePosition, Color.red);

        /* if (Input.GetKeyDown(KeyCode.E))
         {
             MoveColor(Input.GetAxis("Mouse ScrollWheel"));
         }*/
        MoveColor(Input.GetAxis("Mouse ScrollWheel"));

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
	}

    void MoveColor(float mouseValue) {
        /*if (mouseValue > 0f)
        {
            colorIndex = (colorIndex >= colors.Count - 1 ? 0 : colorIndex + 1);
        }
        else if (mouseValue < 0f)
        {
            colorIndex = (colorIndex > 0 ? colorIndex - 1 : colors.Count-1);
        }*/

        mouseValue *= 10;

        for(int i = 0; i < Mathf.Abs(mouseValue); i++)
        {
            colorIndex += 1 * (int)Mathf.Sign(mouseValue);
            if (colorIndex >= colors.Count) colorIndex = 0;
            else if (colorIndex < 0) colorIndex = colors.Count - 1;
        }
        
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
			//Debug.Log ("xxx");
		}
	}

    void Shoot()
    {
        SpriteRenderer temp = Instantiate(bullet, sightDirection.Find("Cannon").position, sightDirection.rotation).GetComponent<SpriteRenderer>();
        temp.color = spriteRenderer.color;
        Destroy(temp.gameObject, 2);

        CamMovement cam = Camera.main.GetComponent<CamMovement>();
        cam.speed = 25;
        cam.impulseDirection = sightDirection.up;
    }

    public int ColorIndex { get { return colorIndex; } }




    /*void OnCollisionEnter2D(Collision2D other){
		if (other.collider.CompareTag ("Block")) {
			Debug.Log ("xxx");
		}
	}*/

    GameObject currentWall;

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("Wall"))
        {
            currentWall = collision.gameObject;
        }*/
    }

    void LateUpdate()
    {
        rigidBody2D.velocity = velocity;
    }

}
