using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlyingShroomPowerUp : PowerUp
{
    bool Flying;
    private bool UsedOnce=false;
    private SpriteRenderer meshrend;
    private Image ShroomSlider;
    void Awake()
    {
        meshrend = GetComponentInChildren<SpriteRenderer>();
    }
    void Start()
    {
        timer = SecondsBeforeExpire;
    }
     private void Update ()
    {

         if(powerUpState==PowerUpState.IsCollected)
         {
             if (!UsedOnce)
             {
                 PowerUpPayload();
                 UsedOnce = true;
                 GameObject obj;
                 obj = GameObject.FindGameObjectWithTag("Shroom_Slider");
                 ShroomSlider = obj.GetComponent<Image>();
                 ShroomSlider.fillAmount = 1;
                
                 meshrend.enabled = false;
                 
             }
             timer -= Time.deltaTime;
             ShroomSlider.fillAmount = timer / SecondsBeforeExpire;
             ExpireAfterSecs();
         }
    }

    protected override void PowerUpPayload()          // Checklist item 1
    {
        base.PowerUpPayload();
        playerBrain.TurtleFlying = true;
    }

    protected override void PowerUpHasExpired()       // Checklist item 2
    {
        
        base.PowerUpHasExpired();
        playerBrain.TurtleFlying = false;
    }
 
}
