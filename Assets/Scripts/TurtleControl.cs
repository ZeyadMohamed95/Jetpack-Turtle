using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurtleControl : MonoBehaviour {
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public GameObject camera;
    public float jumpPower,FlyingPower ;
    public float speed=5f,BonusSpeed=0f;
    public float speedOriginal=5f;
    public static int distanceTraveled;
    public Text coinsCollectedLabel;
    public Text DistanceLabel;
    public bool isPlayerInvulnerable;
    public bool MagnetActive, StarActive;
    public bool TurtleFlying = false;
   
    Vector2 counterJumpForce=new Vector2(0f,-10f);
    float groundRadius = 0.1f;
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public Rigidbody2D rb2d;
    [HideInInspector]
    public BoxCollider2D box;
    [HideInInspector]
    public SpriteRenderer sr;
    bool OnGround = false;
    bool calledonce = false;
    bool jumpKeyHeld;
    [HideInInspector]
    public static int CoinsCollected = 0 ,CrystalsCollected = 0 ;
    public float initialCamPos,CamToPlayerdis;
    // Use this for initialization
    void Start()
    {
        distanceTraveled = 0;
        CoinsCollected = 0;
        CrystalsCollected = 0;
        initialCamPos = camera.transform.position.x - transform.position.x;    
    }

	void Awake () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        box = GetComponent<BoxCollider2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        jumpPower = CalculateJumpForce(Physics2D.gravity.magnitude, 4.0f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        PlayAnim();
        Move();
        //CheckDeath();
        OnGround=Physics2D.OverlapCircle(groundCheck.position,groundRadius,whatIsGround);
        CamToPlayerdis = camera.transform.position.x - distanceTraveled;
        PositionCheck();
        DistanceLabel.text = distanceTraveled.ToString();
        coinsCollectedLabel.text = CoinsCollected.ToString();

	}
    void FixedUpdate()
    {
        
            if (!OnGround)
            {
                if (!jumpKeyHeld && Vector2.Dot(rb2d.velocity, Vector2.up) > 0)
                {
                    rb2d.AddForce(2 * counterJumpForce * rb2d.mass);
                }
            }
        if(TurtleFlying&&jumpKeyHeld)
        {
            rb2d.AddForce(new Vector2(0, FlyingPower * rb2d.mass), ForceMode2D.Impulse);
        }
        
    }
  public void Jump()
    {
        if (!TurtleFlying)
        {
            if (OnGround)
            {
                rb2d.AddForce(new Vector2(0, jumpPower * rb2d.mass), ForceMode2D.Impulse);
                OnGround = false;
            }
        }
        //else if(TurtleFlying&&jumpKeyHeld)
        //{
        //    rb2d.AddForce(new Vector2(0, jumpPower * rb2d.mass),ForceMode2D.Impulse);
        //    OnGround = false;
        //}
    }
   public void SetInvulnerability(bool isInvulnerabilityOn)
   {
       isPlayerInvulnerable = isInvulnerabilityOn;
   }
   //public void SetSpeedReducOn(float speedMultiplier)
   //{
   //    //speedOriginal = speed;
   //    speed *= speedMultiplier;
   //}

   //public void SetSpeedReducOff()
   //{
   //    speed = speedOriginal;
   //}

   public static float CalculateJumpForce(float gravityStrength, float jumpHeight)
   {
       //h = v^2/2g
       //2gh = v^2
       //sqrt(2gh) = v
       return Mathf.Sqrt(2f * gravityStrength * jumpHeight);
   }
   void CollectCoin(Collider2D coinCollider)
   {
       CoinsCollected++;
       FindObjectOfType<AudioManger>().Play("Coin_Gem");
       Destroy(coinCollider.gameObject);
   }
   void CollectCrystal(Collider2D CrystalCollider)
   {
       CrystalsCollected++;
       FindObjectOfType<AudioManger>().Play("Coin_Gem");
       Destroy(CrystalCollider.gameObject);
   }
   void OnTriggerEnter2D(Collider2D collider)
   {
       if (collider.gameObject.CompareTag("Coins"))
       {
           CollectCoin(collider);
       }
       if (isPlayerInvulnerable && collider.gameObject.CompareTag("Enemy"))
       {
           collider.gameObject.GetComponent<On_Click_Duck>().OnMouseDown();
           
       }
       if(collider.gameObject.CompareTag("Crystal"))
       {
           CollectCrystal(collider);
       }
   }
   void OnCollisionEnter2D(Collision2D col)
   {
       if (isPlayerInvulnerable && col.gameObject.CompareTag("Crate"))
       {
           Animator anim;
           BoxCollider2D boxCol2d;
           DestoyOnClick des;
           anim = col.gameObject.GetComponent<Animator>();
           boxCol2d = col.gameObject.GetComponent<BoxCollider2D>();
           des=col.gameObject.GetComponent<DestoyOnClick>();
           anim.SetTrigger("Destroyed");
           boxCol2d.enabled = false;
           des.OnBlockDestroyed();
           Destroy(col.gameObject, 1f);
       }
   }
    void PlayAnim()
   {
       if (anim != null)
       {
           if (OnGround)
           {
               anim.SetBool("Airborne", false);
           }
           else
           {
               anim.SetBool("Airborne", true);
           }
       }

   }
    void Move()
    {
        transform.Translate((speed+BonusSpeed) * Time.deltaTime, 0f, 0f);
        distanceTraveled = (int)transform.localPosition.x;
    }
   public void triggerJumpKeyHeldtrue()
    {
        jumpKeyHeld = true;
    }
  public  void triggerJumpKeyHeldfalse()
    {
        jumpKeyHeld = false;
    }
    void PositionCheck()
  {
      if (CamToPlayerdis > initialCamPos && OnGround && !calledonce)
      {

          BonusSpeed = (speedOriginal * 1.2f)-speedOriginal;
          calledonce = true;
      }
      if (CamToPlayerdis > initialCamPos && !OnGround && calledonce)
      {
          calledonce = false;
          BonusSpeed = 0f;
      }
      if (CamToPlayerdis <= initialCamPos && OnGround && calledonce)
      {
          BonusSpeed = 0f;
          calledonce = false;
      }
  }
   public void ActivateRigidBody()
    {
     if(MainGameController.main.mainGameState==MainGameController.MainGameState.Reviving)
     {
         rb2d.bodyType = RigidbodyType2D.Dynamic;
         MainGameController.main.mainGameState = MainGameController.MainGameState.Playing;
     }
    }
    

}
