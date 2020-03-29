using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat_fly : MonoBehaviour
{
    public int Health = 10;
    public float delay = 0.2f;
    public float speed;
    public GameObject camera;
    public Player player;
    public int dmg = 2;
    public bool visible = false;
    // Use this for initialization
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        speed = 0;
        visible = false;
    }
    void Damage(int damage)
    {
        Health -= damage;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < camera.transform.position.x && Mathf.Abs(transform.position.x - camera.transform.position.x) >= 25)
        {
            Destroy(gameObject);
        }
        if (visible)
        {
            speed = 3;
        }

    }
    void Update()
    {
        Move_ment();
        if (Health <= 0)
        {
            if (delay > 0)
            {
                delay -= Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
                delay = 0.2f;
            }
        }
    }
    private void Move_ment()
    {
        Vector3 vt = transform.position;
        vt.x -= speed * Time.deltaTime;
        transform.position = vt;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (delay > 0)
                delay -= Time.deltaTime;
            else
            {
                player.Damage(2);
                delay = 1.5f;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (delay > 0)
                delay -= Time.deltaTime;
            else
            {
                player.Damage(dmg);
                delay = 1.5f;
            }
        }
    }
    private void OnBecameVisible()
    {
        visible = true;
    }
}
