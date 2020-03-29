using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public float attackDelay = 0.25f;
    public bool attacking = false;
    public Animator anim;
    public Collider2D trigger;
	// Use this for initialization
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown(KeyCode.S)) && !attacking)
        {
            
            attacking = !attacking;
            trigger.enabled = true;
            attackDelay = 0.25f;
        }
        if (attacking)
        {
            if (attackDelay>=0)
            {
                attackDelay -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }
        anim.SetBool("attacking", attacking);
	}
}
