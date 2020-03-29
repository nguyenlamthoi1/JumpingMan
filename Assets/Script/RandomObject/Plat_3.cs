using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat_3 : MonoBehaviour
{
    public GameObject camera;
    public Player player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < camera.transform.position.x && Mathf.Abs(transform.position.x - camera.transform.position.x) >= 25)
        {
            Destroy(gameObject);
        }

    }
}
