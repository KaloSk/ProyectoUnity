using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    public Light luz;
    public Color color;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            luz.enabled = true;
            luz.color = color;
        }
    }

    bool return_light = true;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!return_light) {
                if (luz.intensity < 50) {
                    luz.intensity += 1;
                }
                else
                {
                    return_light = true;
                }
            }
            else
            {
                if (luz.intensity > 1)
                {
                    luz.intensity -= 1;
                }
                else
                {
                    return_light = false;
                }
            }
           
        }

    }


    void OnTriggerExit(Collider other)
    {
        luz.enabled = false;
        luz.intensity = 0;
    }
}
