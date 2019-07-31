using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShot : MonoBehaviour {

	// Use this for initialization
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;
    public bool active=false;
    bool waiting;
    //private AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        
            
        
    }
    void Update()
    {
        if (!waiting&&active)
        {
            StartCoroutine("Fire");
        }
    }
    IEnumerator Fire()
    {
        waiting = true;
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        yield return new WaitForSeconds(fireRate);
        waiting = false;
      //  GetComponent<AudioSource>().Play();
    }
}
