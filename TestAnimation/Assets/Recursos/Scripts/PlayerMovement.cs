using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    class Axis
    {
        public string name;
        public KeyCode negative;
        public KeyCode positive;

        public Axis(string _name, KeyCode _negative, KeyCode _positive)
        {
            name = _name;
            negative = _negative;
            positive = _positive;
        }
    }

    List<Axis> axisList = new List<Axis>();
    public Rigidbody2D rigidbody2D;
    public float speed = 1;
    public Animator playerAnimator;

    public bool isMoving { get { return GetAxis(HORIZONTAL) != 0 || GetAxis(VERTICAL) != 0; }}

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        //spriteRenderer.color = colors[colorIndex];
        axisList.Add(new Axis(HORIZONTAL, KeyCode.A, KeyCode.D));
        axisList.Add(new Axis(VERTICAL, KeyCode.S, KeyCode.W));
    }
	
	// Update is called once per frame
	void Update () {

        playerAnimator.SetBool(MOVING, isMoving);

        Vector3 step = new Vector2(GetAxis(HORIZONTAL), GetAxis(VERTICAL));
        playerAnimator.SetFloat(HORIZONTAL, step.x);
        playerAnimator.SetFloat(VERTICAL, step.y);

        if(isMoving){
            playerAnimator.SetFloat(LAST_HORIZONTAL, step.x);
            playerAnimator.SetFloat(LAST_VERTICAL, step.y);
        }

        Debug.Log(!isMoving);

        step *= speed * Time.deltaTime;
        rigidbody2D.MovePosition(transform.position + step);
	}

    int GetAxis(string axisName)
    {
        Axis axis = axisList.Find(target => target.name == axisName);
        int axisValue = 0;
        if (Input.GetKey(axis.negative))
        {
            axisValue += -1;
        }
        if (Input.GetKey(axis.positive))
        {
            axisValue += 1;
        }
        return axisValue;
    }


    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";
    const string LAST_HORIZONTAL = "LastHorizontal";
    const string LAST_VERTICAL = "LastVertical";
    const string MOVING = "Moving";
}
