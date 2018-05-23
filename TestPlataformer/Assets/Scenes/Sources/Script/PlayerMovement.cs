using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float gravity;
    float verticalSpeed;
    public float horizontalSpeed = 1;
    public float jumpForce = 1;

    bool isGrounded;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGrounded)
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalSpeed = jumpForce;
                isGrounded = false;
            }
        }

        transform.Translate(Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime, 0);


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SpriteRenderer otherRenderer = other.GetComponent<SpriteRenderer>();
        if (otherRenderer!=null && otherRenderer.CompareTag("Plataform"))
        {
            isGrounded = true;
            verticalSpeed = 0;

            ContactFilter2D filter2D = new ContactFilter2D();
            filter2D.useTriggers = true;
            RaycastHit2D[] hits2D = null;
            float currentDistance = 0;//
                
            Physics2D.Raycast(transform.position, Vector3.down, filter2D, hits2D);

            if(hits2D!=null)
            {
                currentDistance = hits2D[0].distance;    
            }


            //transform.Translate(0, 1 - currentDistance, 0);

            Debug.Log(currentDistance);


        } 
        else if (otherRenderer != null && otherRenderer.CompareTag("Death"))
        {
            Destroy(gameObject);
        }
    }
}
