using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarBehaviour : PowerUp {

    private bool UsedOnce = false;
    private SpriteRenderer SR;
    private Image StarSLider;
   // private bool IsInvulerable = true;
	// Use this for initialization
    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        timer = SecondsBeforeExpire;
    }
	// Update is called once per frame
	void Update () {
        if (powerUpState == PowerUpState.IsCollected)
        {
            if (!UsedOnce)
            {
                PowerUpPayload();
                UsedOnce = true;
                SR.enabled = false;
                GameObject obj;
                obj = GameObject.FindGameObjectWithTag("Star_Slider");
                StarSLider = obj.GetComponent<Image>();
                StarSLider.fillAmount = 1;
                
            }

            
            timer -= Time.deltaTime;
            StarSLider.fillAmount = timer / SecondsBeforeExpire;
            ExpireAfterSecs();
        }
		
	}
    protected override void PowerUpPayload()          // Checklist item 1
    {
        base.PowerUpPayload();
        playerBrain.isPlayerInvulnerable = true;
        if (playerBrain.StarActive)
        {
            timer = SecondsBeforeExpire;
        }
        
    }
    protected override void PowerUpHasExpired()       // Checklist item 2
    {
        playerBrain.isPlayerInvulnerable = false;
        playerBrain.StarActive = false;
        base.PowerUpHasExpired();
    }
}
