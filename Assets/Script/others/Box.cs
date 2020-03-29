using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    public int Health = 10;
    public float delay = 0.2f;
    public float speed;
	// Use this for initialization
    void Start()
    {

    }
	void Damage(int damage)
    {
        Health -= damage;
    }
	
	// Update is called once per frame
	void Update () {
        Move_ment();
		if (Health<=0)
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
}
