using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {
    public GameObject prefb;
	// Use this for initialization
	void Start () {
        GameObject obj = (GameObject)Instantiate(prefb);
        obj.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
