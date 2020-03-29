using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
    public Player player;
    public float delay = 0;
    public int dmg = 5;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
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
}
