using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEnd: MonoBehaviour
{
    public Player player;
    public GameObject Player;
    public Vector2 velocity;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(this.transform.position.x, Player.transform.position.x, ref velocity.x, 0);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))  
                player.Damage(5);
    }
   
}
