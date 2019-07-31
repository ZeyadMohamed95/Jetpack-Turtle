using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyOnClick : MonoBehaviour {
    public GameObject coinPrefab,CrystalPrefab;
    public GameObject[] Powerups;
    public float CoinsChance, CrystalChance, PowerUpChance;
    public float forceMultiplier;
    private Animator anim;
    private BoxCollider2D boxCol2d;
    void Awake()
    {
        anim = GetComponent<Animator>();
        boxCol2d = GetComponent<BoxCollider2D>();
    }
	// Use this for initialization
    void OnMouseDown()
    {
        anim.SetTrigger("Destroyed");
        boxCol2d.enabled = false;

        OnBlockDestroyed();
        Destroy(gameObject, 1f);
    }
   public void OnBlockDestroyed()
    {
        float randomnum = Random.value*100;
       if(randomnum<=CoinsChance)
       {
           StartCoroutine(SpawnCoins());
       }
       else if(randomnum<=CoinsChance+PowerUpChance)
       {
           SpawnPowerUp();
       }
       else if(randomnum <=CoinsChance+PowerUpChance+CrystalChance)
       {
           SpawnCrystal();
       }
     
       
       
       FindObjectOfType<AudioManger>().Play("Crate");
    }
   public IEnumerator SpawnCoins()
    {
        
        int num=Random.Range(9,5);
        for (int i = 0; i < num; i++)
        {
           GameObject coin= Instantiate(coinPrefab, transform.position, transform.rotation);
           coin.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * forceMultiplier);
           coin.GetComponent<CircleCollider2D>().enabled = false;
           Destroy(coin, 0.5f);
           FindObjectOfType<AudioManger>().Play("Coin_Gem");
           TurtleControl.CoinsCollected++;
           yield return new WaitForSeconds(0.1f);
        }
    }
    public void SpawnCrystal()
   {
       GameObject Crystal = Instantiate(CrystalPrefab, transform.position, transform.rotation);
       Crystal.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * forceMultiplier);
       Crystal.GetComponent<CapsuleCollider2D>().enabled = false;
       FindObjectOfType<AudioManger>().Play("Coin_Gem");
       Destroy(Crystal, 0.5f);
       TurtleControl.CrystalsCollected++;
   }
    public void SpawnPowerUp()
    {
        GameObject PowerUp = Instantiate(Powerups[Random.Range(0, Powerups.Length)], transform.position, transform.rotation); 
    }

}
