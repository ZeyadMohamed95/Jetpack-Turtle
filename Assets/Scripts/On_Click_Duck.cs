using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Click_Duck : MonoBehaviour {
    private CapsuleCollider2D CapCol;
    private Rigidbody2D rb2d;
    private Animator anim;
    public float forceMultiplier;

        // Use this for initialization
	void Awake () {
        CapCol = GetComponent<CapsuleCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	public void OnMouseDown()
    {
        rb2d.AddForce(new Vector2(0, 1) * forceMultiplier);
        CapCol.enabled = false;
        Destroy(gameObject, 2f);
    }
}
