using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class betweenPost : MonoBehaviour {
    public GameObject camera;
    public Player player;
    public float delay =0f;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
     if (transform.position.x < camera.transform.position.x && Mathf.Abs(transform.position.x - camera.transform.position.x)>= 25)
        {
            Destroy(gameObject);
        }

	}
    /*
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            if (delay > 0)
                delay -= Time.deltaTime;
            else
            {
                player.score += 1;
                delay = 1.5f;
            }
        }
    }
    */
    
}
