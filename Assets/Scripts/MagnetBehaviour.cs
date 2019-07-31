using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnetBehaviour : PowerUp
{

    public CircleCollider2D circol;
    public float fieldRadius;
    public float pullingSpeed = 5f;
    public GameObject[] coins;

    private Image MagnetSLider;
    private SpriteRenderer sr ;
    private bool activmethod;
    void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        circol = GetComponent<CircleCollider2D>();
    }
    void Start()
    {
        timer = SecondsBeforeExpire;
    }
    // Update is called once per frame
    private void Update()
    {

        if (powerUpState == PowerUpState.IsCollected)
        {

            PowerUpPayload();

            sr.enabled = false;
            GameObject obj;
            obj = GameObject.FindGameObjectWithTag("Magnet_Slider");
            MagnetSLider = obj.GetComponent<Image>();
            MagnetSLider.fillAmount = 1;
                
            ExpireAfterSecs();

        }
        if (activmethod)
        {
            attractCoins();
        }
        timer -= Time.deltaTime;
        MagnetSLider.fillAmount = timer / SecondsBeforeExpire;
    }
    protected override void PowerUpPayload()          // Checklist item 1
    {
        base.PowerUpPayload();
        activmethod = true;
        
    }
    protected override void PowerUpHasExpired()       // Checklist item 2
    {
        activmethod = false;
        base.PowerUpHasExpired();
    }

    void attractCoins()
    {
        coins = GameObject.FindGameObjectsWithTag("Coins");
        foreach (GameObject coin in coins)
        {
            float dist = Vector2.Distance(coin.transform.position, playerBrain.transform.position);
            if (dist <= fieldRadius)
            {
                coin.transform.position = Vector2.MoveTowards(coin.transform.position, playerBrain.transform.position, pullingSpeed * Time.deltaTime);
            }
        }
    }
}