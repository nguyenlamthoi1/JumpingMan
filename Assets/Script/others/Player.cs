using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float speed = 250f, maxspeed = 3f, jumPow=220f;
    public bool grounded = true;
    public bool faceright = true;
    public bool doublejump = false;
    public Rigidbody2D r2;
    public Animator anim;
    public SpriteRenderer sren;
    public int ourHealth;
    public int maxHealth=5;
    public int score;
    public float TimeOnAir = 2f;
    
	// Use this for initialization
	void Start () {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        sren = gameObject.GetComponent<SpriteRenderer>();
       
        ourHealth = 5;
        maxHealth = 5;
        score = 0;
        TimeOnAir = 2f;
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("grounded", grounded);
        anim.SetFloat("speed", Mathf.Abs(r2.velocity.x));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                r2.AddForce(Vector2.up * jumPow);
            }
            
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumPow);
                }
            }
            
        }
	}
    void FixedUpdate()
    {
        r2.velocity = new Vector2(maxspeed, r2.velocity.y);
    /*
           float h = Input.GetAxis("Horizontal");
           r2.AddForce(Vector2.right * speed * h);
           if (r2.velocity.x > maxspeed)
               r2.velocity = new Vector2(maxspeed, r2.velocity.y);
           
           if (r2.velocity.x < -maxspeed)
               r2.velocity = new Vector2(-maxspeed, r2.velocity.y);

           
           if (h > 0 && !faceright) { Flip(); }
           if (h < 0 && faceright) { Flip(); }
           
        
        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        }
        */
        if (!grounded)
        {
            if (TimeOnAir > 0) TimeOnAir -=Time.deltaTime;
        }
        if (TimeOnAir <= 0)
        {
            Death();
        }
        if (grounded) TimeOnAir = 2f;
        if (ourHealth<=0)
        {
            Death();
        }

    }
    public void Flip()
    {
        /*
        faceright = !faceright;
        Vector3 scale;
        scale = transform.localScale;
        scale.x *= 1;
        transform.localScale = scale;
        */
        faceright = !faceright;
        sren.flipX = !sren.flipX;
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Damage(int damage)
    {
        ourHealth -= damage;
    }
   
}
