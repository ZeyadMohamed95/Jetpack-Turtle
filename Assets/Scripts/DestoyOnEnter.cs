﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyOnEnter : MonoBehaviour {

	// Use this for initialization
    void OnTriggerEnter2D(Collider2D other)
    { 
            Destroy(other.gameObject); 
    }
}
