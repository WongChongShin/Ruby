using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //Ruby Die and collect coin declaration
    private bool rubyIsDead = false;
    public AudioClip rubyDieSound;   
    public AudioClip coinIsCollected;  

    //Collide Bomb declare
    //public float delay = 1f;
    //float countDown;
    //bool hasExploded = false;
    //public GameObject explosionEffect;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        //Collide bomb starting assign
       // countDown = delay;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2.0f))
        {
            //Collide trap
            if (hit.collider.gameObject.tag == "Trap" && rubyIsDead == false)
            {
                Debug.Log("Game Over!");
                rubyDead(rubyDieSound, true);
            }

            //Collide Bomb
            //if (hit.collider.gameObject.tag == "Bomb")
            //{
            //    countDown -= Time.deltaTime;
            //   if (countDown <= 0f && !hasExploded)
            //    {
            //        Debug.Log("Boom!");
            //        Instantiate(explosionEffect, transform.position, transform.rotation);
            //        Destroy(gameObject);
            //        hasExploded = true;
            //    }
            //}
        }
    }

    //Ruby dead event
    void rubyDead(AudioClip rubyDieSound, bool checkDead)
    {      
        audio.clip = rubyDieSound;
        audio.Play();
        rubyIsDead = checkDead;

    }

    //Ruby collect coin
    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Coin")
        {
            audio.clip = coinIsCollected;
            audio.Play();
            ShadowCoinCollect.numOfCoin++;
            Destroy(collisionInfo.gameObject);
            ShadowCoinCollect.textOn = true;
        }
    }
}