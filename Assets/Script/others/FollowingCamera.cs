using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour {
    public float smoothtimeX, smoothtimeY;
    public Vector2 velocity;
    public GameObject player;
    public bool bound;
    public Vector3 min, max;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float posX = Mathf.SmoothDamp(this.transform.position.x,player.transform.position.x,ref velocity.x,smoothtimeX);
        float posY = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y ,smoothtimeY);
        transform.position = new Vector3(posX, posY,transform.position.z);
        if (bound)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, min.x, max.x),
                Mathf.Clamp(transform.position.y,min.y,max.y),
                Mathf.Clamp(transform.position.z,transform.position.z,transform.position.z));
        }
    }
    
}
