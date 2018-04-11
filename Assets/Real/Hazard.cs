﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Jugador"))
        {
            other.GetComponent<Movimiento>().RestartGame();
        }
    }
}
