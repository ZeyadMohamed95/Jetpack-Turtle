using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
    public GameObject turtle;
    public TurtleControl turtleCntrl;
 //   Rigidbody2D rb2d;
  
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MainGameController.main.mainGameState = MainGameController.MainGameState.Died;
            MainGameController.main.AfterDeath();
            
            turtleCntrl.box.enabled = false;
            turtleCntrl.sr.enabled = false;
            turtleCntrl.rb2d.bodyType=RigidbodyType2D.Static; 
        }
        else
            Destroy(other.gameObject);
    }
}
