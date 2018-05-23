using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowBehaivor : MonoBehaviour {

    public Transform PlayerPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, PlayerPosition.position, 1 * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
        SpriteRenderer otherRenderer = other.GetComponent<SpriteRenderer>();
        if(otherRenderer!=null && other.CompareTag("Player")){
            Destroy(gameObject);
        }
	}

}
