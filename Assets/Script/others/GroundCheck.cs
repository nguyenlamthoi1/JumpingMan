﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    public Player player;
	// Use this for initialization
	void Start () {
        player = gameObject.GetComponentInParent<Player>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground") && !collision.isTrigger)
        player.grounded = true;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ground") && !collision.isTrigger)
            player.grounded = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ground") && !collision.isTrigger)
            player.grounded = false;
    }
    
}
