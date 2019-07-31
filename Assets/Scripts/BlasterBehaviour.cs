using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterBehaviour : PowerUp {

    public SpawnShot spawnshot;
    private bool UsedOnce = false;
    private MeshRenderer meshrend;
    void Awake()
    {
        meshrend = GetComponentInChildren<MeshRenderer>();

    }
    private void Update()
    {

        if (powerUpState == PowerUpState.IsCollected)
        {
            if (!UsedOnce)
            {
                PowerUpPayload();
                UsedOnce = true;
                meshrend.enabled = false;
            }
            ExpireAfterSecs();
        }
    }
    protected override void PowerUpPayload()          // Checklist item 1
    {
        base.PowerUpPayload();
        spawnshot.active = true;
        
    }

    protected override void PowerUpHasExpired()       // Checklist item 2
    {
        spawnshot.enabled = false;
        base.PowerUpHasExpired();
    }
 

}
