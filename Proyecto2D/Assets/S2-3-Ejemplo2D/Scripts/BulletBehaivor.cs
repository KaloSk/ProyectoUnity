using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaivor : MonoBehaviour {

    public int speed = 1;
    SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        SpriteRenderer otherRenderer = other.GetComponent<SpriteRenderer>();
        if (otherRenderer != null && other.CompareTag("Block"))
        {
            if (otherRenderer.color == spriteRenderer.color)
            {
                other.GetComponent<BlockEntity>().DecreaseLife(5);
            }
            else
            {
                other.GetComponent<BlockEntity>().DecreaseLife(1);
            }
            Destroy(transform.gameObject);
        }
       
    }


}
