using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEntity : MonoBehaviour {

    public int lifePoints = 5;

    public void DecreaseLife(int damage) {
        lifePoints -= damage;
        if (lifePoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int getLifePoints()
    {
        return lifePoints;
    }

    int move = 100;
    int xx = 0;
    bool turn = true;
    float speed = 1;

    public void Update()
    {
        if (xx < move && turn)
        {
            transform.position += (Vector3.left * Time.deltaTime * speed);
            xx+=1;
            if(xx==move)
            turn = false;
        }
        else
        {
            transform.position += (Vector3.right * Time.deltaTime * speed);
            xx-=1;
            if (xx <= 0) turn = true;
        }

        Debug.Log(xx);
    }
}
