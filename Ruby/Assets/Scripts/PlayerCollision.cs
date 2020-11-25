using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //Ruby Die and collect coin declaration
    private bool rubyIsDead = false;
    public AudioClip rubyDieSound;   
    public AudioClip coinIsCollected;
    public Animator anim;

    //Collide Bomb declare
    public float delay = 3f;
    float countDown;
    static public bool hasExploded = false;
    public GameObject explosionEffect;

    public float damageRadius = 0.00f;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

        //Collide bomb starting assign
        countDown = delay;

        //declare Bomb Class

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
            if (hit.collider.gameObject.tag == "Bomb")
            {
                Debug.Log("Boom!");
                countDown -= Time.deltaTime;

                if (countDown <= 0f && hasExploded == false)
                {
                    Instantiate(explosionEffect, transform.position, transform.rotation);
                    Destroy(hit.collider.gameObject);
                    hasExploded = true;
                    //Physics.OverlapSphere(transform.position, damageRadius);
                    //foreach (Collider nearByOnject in collider)
                    //{
                    //    //Rigidbody rb = nearByObject.GetComponent<RgidBody>();
                    //    //if (rb != null)
                    //    //{
                    //    //    rb.AddExplosionForce(force, transform.position, damageRadius);
                    //    //}
                    //}
                }
            }
        }
    }

    //Ruby dead event
    void rubyDead(AudioClip rubyDieSound, bool checkDead)
    {      
        audio.clip = rubyDieSound;
        audio.Play();
        anim.SetBool("IsDying", true);
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