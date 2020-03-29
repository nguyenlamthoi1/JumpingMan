using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {
    public GameMaster gm;
    // Use this for initialization
    void Start () {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !col.isTrigger)
        {
            gm.point++;
            Destroy(gameObject);
        }
    }
}
