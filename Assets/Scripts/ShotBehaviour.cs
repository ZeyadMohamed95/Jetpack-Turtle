using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : MonoBehaviour {
    Rigidbody2D rb2d;
    public float speed;
   void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

	void Start () {
        rb2d.velocity = transform.up * speed;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Ground")
        {
            Destroy(gameObject);
        }
        if(other.tag=="Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if(other.tag=="Crate")
        {
            //do shit
        }

    }

}
