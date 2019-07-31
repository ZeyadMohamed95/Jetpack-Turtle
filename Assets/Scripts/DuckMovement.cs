using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour {
    private Rigidbody2D rbd2;
    private float initHeight;
    private float tempzag;
    public float ZigzagSpeed=3f;
    public float ZagRad=1f;
    public float speed=0.05f;
    private float forcemultiplier=1300f;
    GameObject turtle;
    TurtleControl tc;
    bool Direction= true;
    // Use this for initialization
	void Awake () {
        rbd2 = GetComponent<Rigidbody2D>();
        turtle = GameObject.FindGameObjectWithTag("Player");
        tc = turtle.GetComponent<TurtleControl>();
        initHeight = transform.position.y;
        tempzag = ZigzagSpeed;
	}
    void Start()
    {
        FindObjectOfType<AudioManger>().Play("Duck_quack");
    }
	
	// Update is called once per frame
	void Update () {
        Move();
    //    ZigZag();
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!tc.isPlayerInvulnerable &&other.gameObject.tag == "Player")
        {
            MainGameController.main.mainGameState = MainGameController.MainGameState.Died;
            MainGameController.main.AfterDeath();
            tc.rb2d.AddForce(new Vector2(0, 1) * forcemultiplier);
            tc.box.enabled = false;
            
        }
    }
    void Move()
    {
        transform.Translate(-speed * Time.deltaTime, 0f, 0f);
    }
   //void ZigZag()
   // {
   //    transform.Translate(0, ZigzagSpeed*Time.deltaTime, 0f);
   //    if (transform.position.y >= initHeight + ZagRad)
   //    {
   //        ZigzagSpeed = Mathf.Lerp(tempzag, 0, (tempzag / 5) * Time.deltaTime);
   //        //if (ZigzagSpeed == tempzag * -1)
   //        //{
   //        //  Direction = !Direction;
   //        //}
   //    }
   //    //if (transform.position.y >= initHeight + ZagRad)
   //    //{
   //    //    ZigzagSpeed = Mathf.Lerp(-tempzag, tempzag, (tempzag / 3) * Time.deltaTime);
   //    //    if (ZigzagSpeed == tempzag)
   //    //    {
   //    //        Direction = !Direction;
   //    //    }
   //    //}
   // }

}
