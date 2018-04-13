using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour {

    public GameObject objectoToSpawn;
    public bool spawnPossible = true;
    float timer = 0;
    
    public void OnTriggerStay(Collider other) {
        if (other.CompareTag("Follower"))
        {
            spawnPossible = false;
        }
    }

    int a = 0, b = 0, c = 0;

    void Update() {
        if (spawnPossible)
        {
            timer += Time.deltaTime;
            if(timer >= 1)
            {
                a += 10;
                b += 5;
                c += 15;
                Instantiate(objectoToSpawn, transform.position + new Vector3(a,b,c), Quaternion.identity);
                timer = 0;
            }
        }
    }
    
}
