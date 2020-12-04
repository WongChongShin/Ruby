﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //Ruby collect coin declaration 
    public AudioClip coinIsCollected;
    public Animator anim;

    //Ruby collect key
    public int numOfKey = 0;
    static public bool doorOpen = false;
    static public bool youNeedKey = false;
    bool triggerCoinDes = false;

    public GameObject coinDes;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2.0f))
        {
            //Collide trap

            //Collide locked door
            if (hit.collider.gameObject.tag == "LockedDoor")
            {
                if (numOfKey > 0)
                {
                    doorOpen = true;

                }
                else
                {
                    youNeedKey = true;
                }
            }
            //Collide big box
            else if (hit.collider.gameObject.tag == "BigBox")
            {
                anim.SetBool("isPushing", true);
            }
        }
    }

    //Ruby collect coin and key
    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Coin")
        {
            audio.clip = coinIsCollected;
            audio.Play();
            ShadowCoinCollect.numOfCoin++;
            Destroy(collisionInfo.gameObject);
            ShadowCoinCollect.textOn = true;
            triggerCoinDes = true;

            if (triggerCoinDes = true)
            {
                coinDes.SetActive(true);
            }
        }

        else if (collisionInfo.gameObject.tag == "Key")
        {
            audio.clip = coinIsCollected;
            audio.Play();
            numOfKey++;
            Destroy(collisionInfo.gameObject);
        }
        else if (collisionInfo.gameObject.tag == "blueball")
        {
            audio.clip = coinIsCollected;
            audio.Play();

            blueBallCollect.numBlueBall++;
            Destroy(collisionInfo.gameObject);
            blueBallCollect.textOn = true;

            ballCollect.numBlueBall++;
            Destroy(collisionInfo.gameObject);
            ballCollect.textOn = true;

        }
        else if (collisionInfo.gameObject.tag == "greenball")
        {
            audio.clip = coinIsCollected;
            audio.Play();

            greenBallCollect.numGreenBall++;
            Destroy(collisionInfo.gameObject);
            greenBallCollect.textOn = true;

            ballCollect.numGreenBall++;
            Destroy(collisionInfo.gameObject);
            ballCollect.textOn = true;

        }
        else if (collisionInfo.gameObject.tag == "redball")
        {
            audio.clip = coinIsCollected;
            audio.Play();

            redBallCollect.numRedBall++;
            Destroy(collisionInfo.gameObject);
            redBallCollect.textOn = true;

            ballCollect.numRedBall++;
            Destroy(collisionInfo.gameObject);
            ballCollect.textOn = true;

        }
        else if (collisionInfo.gameObject.tag == "explosion")
        {
            healthPoint.health--;
        }
        else if (collisionInfo.gameObject.tag == "Trap")
        {
            healthPoint.health = 0;
        }
    }
}