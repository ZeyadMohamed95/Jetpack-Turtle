using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButtonMethod : MonoBehaviour {
    public GameObject turtle,cam;
    public TurtleControl turtleCntrl;
    SpriteRenderer sr;
    BoxCollider2D box;
    Rigidbody2D rb2d;
    float a, b,dif;
	// Use this for initialization
    void Start()
    {
        a = turtle.transform.position.x;
        b = cam.transform.position.x;
        dif= b - a;
    }
	public void RespawnPlayer()
    {
        MainGameController.main.mainGameState = MainGameController.MainGameState.Reviving;
        MainGameController.main.TotalCrystals--;
        sr = turtle.GetComponentInChildren<SpriteRenderer>();
        sr.enabled = true;
    
        box = turtle.GetComponent<BoxCollider2D>();
        box.enabled = enabled;
        turtleCntrl.rb2d.bodyType = RigidbodyType2D.Static; 
        Invoke("PlayingAfterRespawn", 3f);
        
        turtle.transform.position = new Vector2(+cam.transform.position.x-dif, 2f);
        turtleCntrl.speed = turtleCntrl.speedOriginal;
      //  turtle.transform.position
    }
    public void PlayingAfterRespawn()

    {
        rb2d=turtle.GetComponent<Rigidbody2D>();
        if (rb2d.bodyType == RigidbodyType2D.Static)
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            MainGameController.main.mainGameState = MainGameController.MainGameState.Playing;
        }
    }
}
