using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingplat : MonoBehaviour {
    public float speed = 0.05f, changeDirection = -1;
    Vector3 Move;
    PausedMenu pause;
    // Use this for initialization
    void Start () {
        Move = transform.position;
        pause = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PausedMenu>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!pause.pause)
       
        {
            Move.x += speed;
            transform.position = Move;
        }
	}
 
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("ground"))
        {
            speed *= changeDirection;
        }
       
    }
}
