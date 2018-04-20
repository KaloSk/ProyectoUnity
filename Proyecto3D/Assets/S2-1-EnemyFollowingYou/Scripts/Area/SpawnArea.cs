using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour {

    public GameObject objectoToSpawn;
	public Transform objectToFollow;
	public bool spawnPossible = true;

	public Transform lightBox;
	static public Light lightIndicator;

	float timer = 0;
    
	public void Start(){
		lightIndicator = lightBox.Find ("Point light").GetComponent<Light>();
	}

    public void OnTriggerStay(Collider other) {
        if (other.CompareTag("Follower"))
        {
            spawnPossible = false;
        }
    }

	public void OnTriggerExit(Collider other) {
		if (other.CompareTag("Follower"))
		{
			spawnPossible = true;
		}
	}

    int a = 0, b = 0, c = 0;

    void Update() {
        if (spawnPossible)
        {
            timer += Time.deltaTime;
            if(timer >= 1)
            {
                GameObject spawnedObject = Instantiate(objectoToSpawn, transform.position + new Vector3(a,b,c), Quaternion.identity);
				spawnedObject.transform.Translate (Vector3.down);
				spawnedObject.GetComponent<Follower> ().target = objectToFollow;
				timer = 0;
            }
        }
    }
    
}
