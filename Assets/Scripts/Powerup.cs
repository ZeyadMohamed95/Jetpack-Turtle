using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PowerUp : MonoBehaviour {
    public string powerUpName;
    public string powerUpExplanation;
    [Tooltip("Tick true for power ups that are instant use, eg a health addition that has no delay before expiring")]
    public bool expiresImmediately;
    public float SecondsBeforeExpire = 5f;
    public Image TimerImage;
    protected TurtleControl playerBrain;
    protected SpriteRenderer spriteRenderer;
    protected enum PowerUpState
    {
        InAttractMode,
        IsCollected,
        IsExpiring
    }
    protected PowerUpState powerUpState;
    public float timer ;
    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
	void Start () {
        powerUpState = PowerUpState.InAttractMode;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        PowerUpCollected(other.gameObject);
    }
    
    protected virtual void PowerUpPayload()
    {
        if (expiresImmediately)
        {
            PowerUpHasExpired();
        }
    }
    protected virtual void PowerUpCollected(GameObject gameObjectCollectingPowerUp)
    {
        // We only care if we've been collected by the player
        if (gameObjectCollectingPowerUp.tag != "Player")
        {
            return;
        }

        // We only care if we've not been collected before
        if (powerUpState == PowerUpState.IsCollected || powerUpState == PowerUpState.IsExpiring)
        {
            return;
        }
        powerUpState = PowerUpState.IsCollected;
        playerBrain = gameObjectCollectingPowerUp.GetComponent<TurtleControl>();
        
        // We move the power up game object to be under the player that collect it, this isn't essential for functionality 
        // presented so far, but it is neater in the gameObject hierarchy
        gameObject.transform.parent = playerBrain.gameObject.transform;
        gameObject.transform.position = playerBrain.gameObject.transform.position;

        // Collection effects
       // PowerUpEffects();

        // Payload      
        //PowerUpPayload();
    }
    protected virtual void PowerUpHasExpired()
    {
        if (powerUpState == PowerUpState.IsExpiring)
        {
            return;
        }
        powerUpState = PowerUpState.IsExpiring;

        
      //  Debug.Log("Power Up has expired, removing after a delay for: " + gameObject.name);
        DestroySelfAfterDelay();
    }
    protected virtual void DestroySelfAfterDelay()
    {
        // Arbitrary delay of some seconds to allow particle, audio is all done
        // TODO could tighten this and inspect the sfx? Hard to know how many, as subclasses could have spawned their own
        Destroy(gameObject, SecondsBeforeExpire);
    }
   protected void ExpireAfterSecs()
    {       
        if (timer <= 0)
        {
            PowerUpHasExpired();
        }
    }
}

