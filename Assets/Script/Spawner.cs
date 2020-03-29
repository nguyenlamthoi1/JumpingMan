using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject player;
    public Player player_info;
    public GameMaster gm;

    // 2 object need to randomly appear
    public GameObject PostSpikes;
    public GameObject betweenPost;
    public GameObject plat;
    public GameObject bat;
        public int num_of_plat = 0;
    public Vector3 pos;
    public int must_doublej = 1;
    public int num_of_rand_ob = 0;
    //_________________________________


    public int max = 4;
    public int num_post=0;
    public float timedelay=0;
    
  
	// Use this for initialization
	void Start () {
        pos = this.transform.position; //position of first between post

        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        player = GameObject.FindGameObjectWithTag("Player");
        player_info= GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        StartCoroutine(Spawner_lv1());
        num_post = 0;
        timedelay = 0;
        num_of_rand_ob=0;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        /*
        if (Mathf.Abs(player.transform.position.x - pos.x) <= 25)
        {
            if (timedelay <= 0)
            {
                if (num_post != max)
                {
                    switch (player_info.score / 10)
                    {
                        case 0:
                            {
                                num_post++;
                                StartCoroutine(Spawner_lv1());                               
                                break;
                            }
                           
                    }
                }
                else
                {
                    timedelay = 3;
                    num_post = 0;
                }
            }
            else
            {
                timedelay -= Time.deltaTime;
            }
        }
        */
        if (pos.x - player.transform.position.x <= 25)
        {
            if (timedelay <= 0)
            {
                if (num_post != max)
                {
                    if (num_of_rand_ob <= 10)
                    {
                        num_post++;
                        StartCoroutine(Spawner_lv1());
                    }

                    else if (num_of_rand_ob <=30)
                    { 
                        num_post++;
                        StartCoroutine(Spawner_lv2());     
                          
                    }
                    else if (num_of_rand_ob <=40)
                    {
                        num_post++;
                        StartCoroutine(Spawner_lv3());
                    }
                }
                else
                {
                    timedelay = 3;
                    num_post = 0;
                }
            }
            else
            {
                timedelay -= Time.deltaTime;
            }
        }
    }
    IEnumerator Spawner_lv1()
    {
        yield return new WaitForSeconds(timedelay);
        // get number of plat random from 1 to 4
        num_of_plat = Random.Range(1, 5);
       
        //Instantiate first plat________________
        pos.x = pos.x + 4f * Random.Range(1, 3);
        pos.y = pos.y - Random.Range(1, 3);
        num_of_rand_ob++;
        Instantiate(plat, pos, Quaternion.identity);
        //_________Instantiate_the_rest______________
        for (int i=1; i<= num_of_plat-1;i++)
        {
            
            pos.x = pos.x + 4.5f * Random.Range(1, 3);
            pos.y = pos.y + 0.8f*Random.Range(-2, 2);
            num_of_rand_ob++;
            Instantiate(plat, pos, Quaternion.identity);
        }
        //_________________________________________
        int a = Random.Range(1, 3);
        if (a == 1)
            //pos.x = pos.x + 4f * Random.Range(1, 3);
            pos.x = pos.x + 4f;
        else { pos.x = pos.x + 9f; }
        pos.y = pos.y + Random.Range(1, 3);
        num_of_rand_ob++;
        Instantiate(betweenPost, pos, Quaternion.identity);
    }
    IEnumerator Spawner_lv2()
    {
        yield return new WaitForSeconds(timedelay);
        // get number of plat random from 1 to 2;
        num_of_plat = Random.Range(1, 3);
        must_doublej = Random.Range(0, 2);
        //Instantiate first plat________________
        if (must_doublej == 1)
        {
            pos.x = pos.x + 5.5f;
            pos.y = pos.y - 1.93f;
        }
        else
        {
            pos.x = pos.x + 3f*Random.Range(1,3);
            pos.y = pos.y - 1.93f;
        }
        num_of_rand_ob++;
        Instantiate(plat, pos, Quaternion.identity);
        //_________Instantiate_the_rest______________
        for (int i = 1; i <= num_of_plat - 1; i++)
        {

            pos.x = pos.x + 4.5f * Random.Range(1, 3);
            pos.y = pos.y + 0.8f * Random.Range(-2, 2);
            num_of_rand_ob++;
            Instantiate(plat, pos, Quaternion.identity);
        }
        //_________________________________________
        if (must_doublej == 1)
        {
            pos.x = pos.x + 4.5f;
            pos.y = pos.y + 1.93f;
        }
        else
        {
            pos.x = pos.x + 3f;
            pos.y = pos.y + 1.93f;
        }
        num_of_rand_ob++;
        Instantiate(PostSpikes, pos, Quaternion.identity);
    }
    IEnumerator Spawner_lv3()
    {
        yield return new WaitForSeconds(timedelay);
        // get number of plat random from 1 to 2;
       
        num_of_plat = Random.Range(1, 3);
        must_doublej = Random.Range(0, 2);
        //Instantiate first plat________________
        if (must_doublej == 1)
        {
            pos.x = pos.x + 5.5f;
            pos.y = pos.y - 1.93f;
        }
        else
        {

            pos.x = pos.x + 3f * Random.Range(1, 3);
            pos.y = pos.y - 1.93f;
        }
        num_of_rand_ob++;
        Instantiate(plat, pos, Quaternion.identity);
        //random if we will create bat or not
        int have_bat = Random.Range(0,2);    
        if (have_bat==1)
        {
            Vector2 pos_bat;
            pos_bat.x = pos.x + Random.Range(0, 3f);
            pos_bat.y = pos.y + 1.5f;
            Instantiate(bat, pos_bat, Quaternion.identity);
        }
        //__________________________________
        //_________Instantiate_the_rest______________
        for (int i = 1; i <= num_of_plat - 1; i++)
        {

            pos.x = pos.x + 4.5f * Random.Range(1, 3);
            pos.y = pos.y + 0.8f * Random.Range(-2, 2);
            num_of_rand_ob++;
            Instantiate(plat, pos, Quaternion.identity);
            //random if we will create bat or not
            have_bat = Random.Range(0, 2);
            if (have_bat == 1)
            {
                Vector2 pos_bat;
                pos_bat.x = pos.x + Random.Range(0, 3f);
                pos_bat.y = pos.y + 1.5f;
                Instantiate(bat, pos_bat, Quaternion.identity);
            }
            //__________________________________
        }
        //_________________________________________
        if (must_doublej == 1)
        {
            pos.x = pos.x + 4.5f;
            pos.y = pos.y + 1.93f;
        }
        else
        {
            pos.x = pos.x + 3f;
            pos.y = pos.y + 1.93f;
        }
        num_of_rand_ob++;
        Instantiate(PostSpikes, pos, Quaternion.identity);
        have_bat = Random.Range(0, 2);
        if (have_bat == 1)
        {
            Vector2 pos_bat;
            pos_bat.x = pos.x + Random.Range(0, 3f);
            pos_bat.y = pos.y;
            Instantiate(bat, pos_bat, Quaternion.identity);
        }
    }
}
