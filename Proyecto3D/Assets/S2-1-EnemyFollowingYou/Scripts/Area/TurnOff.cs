using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{

    public Light luz;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            luz.enabled = false;
        }
    }
}