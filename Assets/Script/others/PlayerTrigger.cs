using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour {
    public int dmg = 10;
	// Use this for initialization
	private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }
    }
}
